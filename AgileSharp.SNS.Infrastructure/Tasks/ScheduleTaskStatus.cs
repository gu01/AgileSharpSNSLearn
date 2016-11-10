using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Infrastructure.Tasks
{
    public enum ScheduleTaskStatus
    {
        NotStart,
        Processing,
        Completed,
        Stop,
        Fault
    }
}
