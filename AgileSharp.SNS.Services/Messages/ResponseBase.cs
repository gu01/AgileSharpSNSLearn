using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Services.Messages
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
