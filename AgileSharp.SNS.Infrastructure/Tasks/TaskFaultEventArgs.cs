using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Infrastructure.Tasks
{
    public class TaskFaultEventArgs
    {
        public string TaskName { get; set; }
        public object TaskParameter { get; set; }
        public Dictionary<string, string> TaskUserData { get; set; }
    }
}
