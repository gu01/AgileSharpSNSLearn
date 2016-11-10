using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Authenticate;

namespace AgileSharp.SNS.Services.Messages
{
    public class LoginRequest
    {
        public AuthenticateType AuthenticateType { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
