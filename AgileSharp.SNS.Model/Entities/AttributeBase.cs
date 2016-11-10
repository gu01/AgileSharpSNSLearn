using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class AttributeBase
    {
        public int AttributeId { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public Binary Version { get; set; }
    }
}
