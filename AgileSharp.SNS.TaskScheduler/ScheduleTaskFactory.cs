using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AgileSharp.Platform.Core.Common;
using System.Reflection;

namespace AgileSharp.Platform.Core.Tasks
{
    public static class ScheduleTaskFactory
    {
        private static Dictionary<string, IScheduleTask> tasks = new Dictionary<string, IScheduleTask>();

        public static IScheduleTask Create(string taskName)
        {
            IScheduleTask result = null;
            if (taskName.IsNotEmpty())
            {
                string taskType = taskName.Trim().Split(',')[0];
                string assemblyName = taskName.Trim().Split(',')[1];

                if (tasks.ContainsKey(taskType))
                {
                    result = tasks[taskType];
                }
                else
                {
                    var assembly = Assembly.GetExecutingAssembly() ;
                    var obj = assembly.CreateInstance(taskType);
                    if (obj == null)
                    {
                        assembly = Assembly.Load(assemblyName);
                        result = (IScheduleTask)assembly.CreateInstance(taskType);
                    }
                     
                    tasks.Add(taskType, result);
                }
            }
            return result;
        }

        public static void Clear()
        {
            tasks.Clear();
        }
    }
}
