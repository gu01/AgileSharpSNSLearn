using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class TermViewModel
    {
        public int TermId { get; set; }
        public string Name { get; set; }
        public string TermContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Binary Version { get; set; }
    }
}
