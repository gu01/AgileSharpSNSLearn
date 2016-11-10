using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Model.Entities
{
    public class AccountGrade
    {
        public int GradeId { get; set; }
        public int AccountId { get; set; }
        public int TotalGrade { get; set; }
        public int MonthlyGrade { get; set; }
    }
}
