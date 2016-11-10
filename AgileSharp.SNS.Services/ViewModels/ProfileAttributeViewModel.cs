using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class ProfileAttributeViewModel
    {
        public int AttributeId { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public Binary Version { get; set; }
        public int ProfileId { get; set; }
        public VisibilityLevel VisibilityLevel { get; set; }
    }
}
