using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using System.Security.Cryptography;
using StructureMap;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Infrastructure;
using AgileSharp.SNS.Infrastructure.Config;

namespace AgileSharp.SNS.Services
{
    public static class ServiceHelper
    {
        static readonly RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
 

        public static string GenerateRandomPassword(Account account)
        {
            byte[] randomKey = new byte[10];
            rngProvider.GetBytes(randomKey);
            string hex = BitConverter.ToString(randomKey);
            return hex.Replace("-", "");
        }

        public static void SendRecoverPasswordEmail(Account account)
        {
            if (account != null)
            {
                var emailService = ObjectFactory.GetInstance<IEmail>();
                emailService.SendEmail(account.Email, "您的新密码", string.Format("您的新密码为{0},请您尽快更改密码!", account.Password));
            }
        }

        public static void SendActiveEmail(Account account)
        {
            var configurationService = ObjectFactory.GetInstance<IConfiguration>();
            var emailService = ObjectFactory.GetInstance<IEmail>();

            string encryptedName = Cryptography.Encrypt(account.Email, "verify");
            string message = "请您点击下面的链接激活您的账号<br/>" +
                "<a href=\"" + configurationService.EmailVerifyAddress + "?key=" + encryptedName +
                "\">" + "激活账号" + "</a>";
            emailService.SendEmail(account.Email, "账号已经成功创建，请您激活！", message);
        }
    }
}
