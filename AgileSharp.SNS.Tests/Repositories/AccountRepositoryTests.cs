using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Model.Entities;


namespace AgileSharp.SNS.Tests.Repositories
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        IAccountRepository repository = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            repository = ObjectFactory.GetInstance<IAccountRepository>();
        }

        [Test]
        public void Test_GetAccountByUsername()
        {
            var repository = ObjectFactory.GetInstance<IAccountRepository>();
            Assert.IsNotNull(repository, "AccountRepository is null");
            var result = repository.GetAccountByUsername("wangyang");
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Username, "wangyang");
        }

        [Test]
        public void Test_GetAccountByEmail()
        {
            var result = repository.GetAccountByEmail("wangyang@yahoo.com");
            Assert.IsNotNull(result);
        }

        [Test]
        public void Test_Add_Account()
        {
            var account = new Account
            {
                Username = "xiaopan",
                Password = "123456",
                Email = "xiaopan@yahoo.com",
                TermId = 1
            };
            var result = repository.Save(account);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_GetAccountById()
        {
            var result = repository.GetAccountById(6);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Test_Update_Account()
        {
            var account = repository.GetAccountById(6);
            Assert.IsNotNull(account);
            if (account != null)
            {
                account.Email = "aa@hp.com";
            }
            var result = repository.Save(account);
            Assert.AreEqual(true, result, "Update account failed");

        }

        [Test]
        public void Test_GetAllAccounts_With_EmptyQueryString()
        {
            int total = 0;
            var list = repository.GetAllAccounts(string.Empty, 0, 3, ref total);
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void Test_GetAllAccounts_With_QueryString()
        {
            int total = 0;
            var list = repository.GetAllAccounts("yahoo.com", 0, 3, ref total);
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
        }
    }
}
