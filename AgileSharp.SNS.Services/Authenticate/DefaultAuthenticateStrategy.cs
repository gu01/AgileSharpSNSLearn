using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Infrastructure;
using StructureMap;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.Mappings;

namespace AgileSharp.SNS.Services.Authenticate
{
    public class DefaultAuthenticateStrategy : IAuthenticateStrategy
    {
        public LoginResponse Validate(string email, string password)
        {
            LoginResponse result = new LoginResponse();

            var account = ObjectFactory.GetInstance<IAccountRepository>().GetAccountByEmail(email);
            if (account != null)
            {
                password = password.Encrypt(email);
                if (account.Password == password)
                {
                    if (account.EmailVerfied)
                    {
                        result.CurrentAccount = account.ToViewModel();
                        result.IsSuccess = true;
                    }
                    else
                    {
                        ServiceHelper.SendActiveEmail(account);
                        result.ErrorMessage = "请您到邮箱中激活账号！";
                    }
                }
                else
                {
                    result.ErrorMessage = "您输入的密码不正确！";
                }
            }
            else
            {
                result.ErrorMessage = "请重新检查您输入的用户名和密码！";
            }

            return result;
        }
    }
}
