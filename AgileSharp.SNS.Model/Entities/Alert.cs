using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Alert
    {
        public int AlertId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreateDate { get; set; }
        public Binary Version { get; set; }
        public AlertType AlertType { get; set; }
        public bool IsHidden { get; set; }
        public string Message { get; set; }
    }
}
