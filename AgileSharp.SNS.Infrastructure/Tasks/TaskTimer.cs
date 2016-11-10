using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace AgileSharp.SNS.Infrastructure.Tasks
{
    public class TaskTimer : Timer
    {
        public string Name { get; set; }
    }
}
