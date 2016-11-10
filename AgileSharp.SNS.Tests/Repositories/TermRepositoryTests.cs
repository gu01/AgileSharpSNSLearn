using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Repository;

namespace AgileSharp.SNS.Tests.Repositories
{
    [TestFixture]
    public class TermRepositoryTests
    {
        ITermRepository repository = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            repository = ObjectFactory.GetInstance<ITermRepository>();
        }

        [Test]
        public void Test_GetCurrentTerm()
        {
            var term = repository.GetCurrentTerm();
            Assert.IsNotNull(term);
        }

        [Test]
        public void Test_SaveTerm()
        {
            var term = repository.GetCurrentTerm();
            Assert.IsNotNull(term);
            term.TermContent = "This is a demo";
            var result = repository.Save(term);
            Assert.AreEqual(true, result, "Save Term Filded");
        }

        [Test]
        public void Test_GetTermContentByName()
        {
            var term = repository.GetTermContentByName("Test");
            Assert.IsNotNull(term);
        }
    }
}
