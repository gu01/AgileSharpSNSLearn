using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.Platform.Core.Tasks
{
    public abstract class ScheduleBaseTask : IScheduleTask
    {
        #region Properties

        public bool IsEabled
        {
            get;
            set;
        }

        public object Parameter
        {
            get;
            set;
        }

        public ScheduleTaskRule Rule
        {
            get;
            set;
        }

        public ScheduleTaskStatus Status
        {
            get;
            set;
        }

        public string TaskName
        {
            get;
            set;
        }

        public Dictionary<string, string> UserData
        {
            get;
            set;
        }

        public event TaskCompletedEventHandler TaskCompleted;

        public event TaskFaultEventHandler TaskFault;

        #endregion

        #region Main Methods

        public ScheduleBaseTask()
        {
            UserData = new Dictionary<string, string>();
        }

        public void Execute()
        {
            try
            {
                if (IsEabled && (Status == ScheduleTaskStatus.NotStart || Status == ScheduleTaskStatus.Stop))
                {
                    Status = ScheduleTaskStatus.Processing;
                    ExecuteCore();
                }

            }
            catch (Exception ex)
            {
                Status = ScheduleTaskStatus.Fault;
                OnTaskFault(new TaskFaultEventArgs { TaskName = this.TaskName, TaskParameter = this.Parameter, TaskUserData = UserData });
                //Log later
            }

            Status = ScheduleTaskStatus.Completed;
            OnTaskCompleted(new TaskCompletedEventArgs { TaskName = this.TaskName, TaskParameter = this.Parameter, TaskUserData = UserData });
        }

        #endregion

        #region Abstract Methods

        protected abstract void ExecuteCore();

        #endregion

        #region Event Invoke Methods

        protected virtual void OnTaskCompleted(TaskCompletedEventArgs args)
        {
            if (TaskCompleted != null)
                TaskCompleted(this, args);
        }

        protected virtual void OnTaskFault(TaskFaultEventArgs args)
        {
            if (TaskFault != null)
                TaskFault(this, args);
        }

        #endregion
    }
}
