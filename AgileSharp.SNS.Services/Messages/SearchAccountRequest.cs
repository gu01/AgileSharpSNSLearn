using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Services.Messages
{
    public class SearchAccountRequest
    {
        public string QueryString { get; set; }
        public int StartIndex { get; set; }
        public int RequestCount { get; set; }
    }
}
