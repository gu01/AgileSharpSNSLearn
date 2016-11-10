using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        IAccountService accountService = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            AutoMapperBootStrapper.ConfigureAutoMapper();
            accountService = ObjectFactory.GetInstance<IAccountService>();
        }

        [Test]
        public void Test_UsernameInUse()
        {
            var result = accountService.UsernameInUse("wangyang");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_EmailInUse()
        {
            var result = accountService.EmailInUse("aa@hp.com");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_Account_Login()
        {
            var request = new LoginRequest
            {
                Email = "wangyang@yahoo.com",
                Password = "wangyang"
            };
            var response = accountService.Login(request);
            Assert.AreEqual(response.IsSuccess, true);
        }

        [Test]
        public void Test_SaveAccount()
        {
            AccountViewModel model = new AccountViewModel();
            model.Email = "yang@ya.com";
            model.Password = "1123";
            model.TermId = 1;
            var result = accountService.SaveAccount(model);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_RecoverPassword()
        {
            var result = accountService.RecoverPassword("yang@ya.com");
            Assert.AreEqual(true, result);
        }
    }
}
