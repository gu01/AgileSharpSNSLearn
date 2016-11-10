using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class StatusUpdate
    {
        public long StatusUpdateId { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int AccountId { get; set; }
        public Binary Version { get; set; }
    }
}
