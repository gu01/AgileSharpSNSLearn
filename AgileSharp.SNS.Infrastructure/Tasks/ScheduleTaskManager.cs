using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Configuration;
using System.Timers;
using StructureMap;
using AgileSharp.SNS.Infrastructure.Logging;
using AgileSharp.SNS.Infrastructure.Files;


namespace AgileSharp.SNS.Infrastructure.Tasks
{
    public class ScheduleTaskManager
    {
        #region Fields

        private Dictionary<string, TaskTimer> schedulersContainer = new Dictionary<string, TaskTimer>();
        private Dictionary<string, List<IScheduleTask>> tasksContainer = new Dictionary<string, List<IScheduleTask>>();
        private static readonly object m_lockHelper = new object();
        private static ScheduleTaskManager m_instance = null;

        #endregion

        #region Properties

        public bool IsMaster { get; private set; }
        public string TaskConfigPath { get; private set; }
        public string ServerName { get; private set; }
        public bool EnableDistributed { get; private set; }

        public static ScheduleTaskManager GetInstance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_lockHelper)
                    {
                        if (m_instance == null)
                        {
                            m_instance = new ScheduleTaskManager();
                        }
                    }
                }
                return m_instance;
            }
        }

        #endregion

        #region Private Methods

        private ScheduleTaskManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            TaskConfigPath = ConfigurationManager.AppSettings["TaskConfigPath"];
            if (!TaskConfigPath.IsNotEmpty())
            {
                TaskConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Configs", "tasks.config");
            }

            if (File.Exists(TaskConfigPath))
            {
                var monitor = FileWatcherManager.CreateWatcherFor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs"), "tasks.config");
                if (monitor != null)
                {
                    monitor.Changed += new FileSystemEventHandler(monitor_Changed);
                }

                LoadTaskSettings();
                InitTasksContainer();
                LoadTasks();
                InitSheduler();
            }
        }

        void monitor_Changed(object sender, FileSystemEventArgs e)
        {
            Stop();
            ClearTasksContainer();
            LoadTaskSettings();
            ScheduleTaskFactory.Clear();
            LoadTasks();
            Run();

        }

        private void LoadTaskSettings()
        {
            var element = ConfigurationReader.FindElements(TaskConfigPath, "TaskSettings");
            if (element != null)
            {
                ServerName = element.Attributes["serverName"].Value;
                EnableDistributed = element.Attributes["enableDistributed"].Value.SafeBoolParse();
            }
        }

        private void LoadTasks()
        {
            var tasksElement = ConfigurationReader.FindElements(TaskConfigPath, "Tasks");
            if (tasksElement != null)
            {
                if (tasksElement.HasChildNodes)
                {
                    var elements = tasksElement.ChildNodes;

                    for (int i = elements.Count - 1; i >= 0; i--)
                    {
                        var element = elements[i];
                        if (element.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            var task = ScheduleTaskFactory.Create(element.Attributes["type"].Value);
                            if (task != null)
                            {
                                task.TaskName = element.Attributes["name"].Value;

                                ScheduleTaskRule rule = ScheduleTaskRule.PerMonth;
                                if (Enum.TryParse<ScheduleTaskRule>(element.Attributes["rules"].Value, out rule))
                                {
                                    task.Rule = rule;
                                }
                                task.IsEabled = element.Attributes["enabled"].Value.SafeBoolParse();
                                tasksContainer[rule.ToString()].Add(task);

                                for (int j = element.Attributes.Count - 1; j >= 0; j--)
                                {
                                    if (!(string.Compare(element.Attributes[j].Name, "type") == 0 ||
                                        string.Compare(element.Attributes[j].Name, "name") == 0 ||
                                        string.Compare(element.Attributes[j].Name, "rules") == 0 ||
                                        string.Compare(element.Attributes[j].Name, "enabled") == 0))
                                    {
                                        task.UserData.Add(element.Attributes[j].Name, element.Attributes[j].Value);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InitTasksContainer()
        {
            var rules = Enum.GetNames(typeof(ScheduleTaskRule));
            for (int i = rules.Length - 1; i >= 0; i--)
            {
                tasksContainer.Add(rules[i], new List<IScheduleTask>());
            }
        }

        private void InitSheduler()
        {
            var rules = Enum.GetNames(typeof(ScheduleTaskRule));
            for (int i = rules.Length - 1; i >= 0; i--)
            {
                switch (rules[i])
                {
                    case "Per1Minutes":
                        AddScheduler("Per1Minutes", 1000 * 10);
                        break;
                    case "Per5Minutes":
                        AddScheduler("Per5Minutes", 1000 * 60 * 5);
                        break;
                    case "Per15Minutes":
                        AddScheduler("Per15Minutes", 1000 * 60 * 15);
                        break;
                    case "Per1Hour":
                        AddScheduler("Per1Hour", 1000 * 60 * 60);
                        break;
                    case "Per2Hour":
                        AddScheduler("Per2Hour", 1000 * 60 * 120);
                        break;
                    case "PerDay":
                        AddScheduler("PerDay", 1000 * 60 * 60 * 24);
                        break;
                    case "PerWeek":
                        AddScheduler("PerWeek", 1000 * 60 * 60 * 24 * 7);
                        break;
                    case "PerMonth":
                        AddScheduler("PerMonth", 1000 * 60 * 60 * 24 * 21);
                        break;
                }
            }
        }

        private void AddScheduler(string name, double interval)
        {
            TaskTimer scheduler = null;
            scheduler = new TaskTimer();
            scheduler.Enabled = true;
            scheduler.Elapsed += new ElapsedEventHandler(scheduler_Elapsed);
            scheduler.Interval = interval;
            scheduler.Name = name;
            schedulersContainer.Add(name, scheduler);
        }

        void scheduler_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timer = sender as TaskTimer;
            if (tasksContainer.ContainsKey(timer.Name))
            {
                var tasks = tasksContainer[timer.Name];
                if (tasks.IsNotNull())
                {
                    for (int i = tasks.Count - 1; i >= 0; i--)
                    {
                        if (tasks[i].IsEabled)
                        {
                            tasks[i].Execute();
                        }
                    }

                }
            }
        }

        private void IsActiveTask(IScheduleTask task, bool isActive)
        {
            if (task != null)
            {
                if (tasksContainer.ContainsKey(task.Rule.ToString()))
                {
                    var existTask = tasksContainer[task.Rule.ToString()].Where(u => string.Compare(u.TaskName, task.TaskName) == 0).FirstOrDefault();
                    if (existTask != null)
                    {
                        existTask.IsEabled = isActive;
                    }
                }
            }
        }

        private void ClearTasksContainer()
        {
            foreach (var value in tasksContainer.Values)
            {
                value.Clear();
            }
        }

        #endregion

        #region Main Methods

        public void Run()
        {
            try
            {
                foreach (var scheduler in schedulersContainer.Values)
                {
                    scheduler.Start();
                }
            }
            catch (Exception ex)
            {
                ObjectFactory.GetInstance<ILogger>().Fatal(typeof(ScheduleTaskManager), "ScheduleTaskManager Run", ex);
            }

        }

        public void ActiveTask(IScheduleTask task)
        {
            IsActiveTask(task, true);
        }

        public void Stop()
        {
            try
            {
                Initialize();
                foreach (var scheduler in schedulersContainer.Values)
                {
                    scheduler.Enabled = false;
                    scheduler.Stop();
                }
            }
            catch (Exception ex)
            {
                ObjectFactory.GetInstance<ILogger>().Fatal(typeof(ScheduleTaskManager), "ScheduleTaskManager Stop", ex);
            }
        }

        public void StopTask(IScheduleTask task)
        {
            IsActiveTask(task, false);
        }

        public void StartNew(Action<object> methods, object parameter, ScheduleTaskRule rule)
        {
            var commonTask = new CommonTask(methods);
            commonTask.IsEabled = true;
            commonTask.Parameter = parameter;
            tasksContainer[rule.ToString()].Add(commonTask);
        }

        public void StartNew(Action methods, ScheduleTaskRule rule)
        {
            var commonTask = new CommonTask(methods);
            commonTask.IsEabled = true;
            tasksContainer[rule.ToString()].Add(commonTask);
        }

        #endregion
    }
}
