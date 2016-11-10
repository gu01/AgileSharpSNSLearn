using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class ProfileAttribute : AttributeBase
    {
        public int ProfileId { get; set; }
        public VisibilityLevel VisibilityLevel { get; set; }
    }
}
