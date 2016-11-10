using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class SearchProductRequest   
    {
        public int CategoryId { get; set; }
        public string QueryString { get; set; }
        public int StartIndex { get; set; }
        public int RequestCount { get; set; }
    }
}
