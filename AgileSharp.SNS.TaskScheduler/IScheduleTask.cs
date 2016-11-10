using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.Platform.Core.Tasks
{
    public interface IScheduleTask
    {
        bool IsEabled { get; set; }
        object Parameter { get; set; }
        ScheduleTaskRule Rule { get; set; }
        ScheduleTaskStatus Status { get; set; }
        string TaskName { get; set; }
        event TaskCompletedEventHandler TaskCompleted;
        event TaskFaultEventHandler TaskFault;
        Dictionary<string, string> UserData { get; set; }
        void Execute();
    }
}
