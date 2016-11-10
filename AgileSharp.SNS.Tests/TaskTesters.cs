using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Infrastructure.Tasks;

namespace AgileSharp.SNS.Tests
{
    public class TaskTesters
    {
        public void Run()
        {
            ScheduleTaskManager.GetInstance.StartNew(() =>
                {
                    //do....
                }, ScheduleTaskRule.Per1Minutes);
        }
    }
}
