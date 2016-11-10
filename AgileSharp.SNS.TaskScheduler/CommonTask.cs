using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.Platform.Core.Tasks
{
    public class CommonTask : ScheduleBaseTask
    {
        private Action<object> parameterMethod;
        private Action commandMethod;

        public CommonTask()
        {
        }

        public CommonTask(Action<object> method)
        {
            this.parameterMethod = method;
        }

        public CommonTask(Action method)
        {
            this.commandMethod = method;
        }

        protected override void ExecuteCore()
        {
            if (this.parameterMethod != null)
            {
                this.parameterMethod.Invoke(this.Parameter);
            }

            if (this.commandMethod != null)
            {
                this.commandMethod.Invoke();
            }
        }
    }
}