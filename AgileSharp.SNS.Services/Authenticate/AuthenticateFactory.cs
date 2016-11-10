using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Services.Authenticate
{
    public static class AuthenticateFactory
    {
        public static IAuthenticateStrategy CreateAuthenticate(AuthenticateType type)
        {
            switch (type)
            {
                case AuthenticateType.Default:
                    return new DefaultAuthenticateStrategy();
                case AuthenticateType.Google:
                    return new JanrainAuthenticateStrategy();
            }
            return null;
        }
    }
}
