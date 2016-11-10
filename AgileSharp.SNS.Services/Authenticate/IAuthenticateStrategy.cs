using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Messages;

namespace AgileSharp.SNS.Services.Authenticate
{
    public interface IAuthenticateStrategy
    {
        LoginResponse Validate(string email, string password);
    }
}
