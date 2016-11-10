﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Infrastructure.Tasks
{
    public enum ScheduleTaskRule
    {
        Per1Minutes,
        Per5Minutes,
        Per15Minutes,
        Per1Hour,
        Per2Hour,
        PerDay,
        PerWeek,
        PerMonth
    }
}
