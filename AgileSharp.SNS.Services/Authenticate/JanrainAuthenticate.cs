using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Messages;
using System.Net;

namespace AgileSharp.SNS.Services.Authenticate
{
    public class JanrainAuthenticateStrategy : IAuthenticateStrategy
    {
        public LoginResponse Validate(string email, string password)
        {
            return null;
        }
    }
}
