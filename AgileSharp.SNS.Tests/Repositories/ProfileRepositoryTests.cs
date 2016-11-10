using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileSharp.SNS.Model.Repositories;
using StructureMap;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Tests.Repositories
{
    [TestFixture]
    public class ProfileRepositoryTests
    {
        IProfileRepository repository = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            repository = ObjectFactory.GetInstance<IProfileRepository>();
        }

        [Test]
        public void Test_AddProfile()
        {
            var profile = new Profile
            {
                AccountId = 6,
                ProfileName = "testProfile",
                CreateDate = DateTime.Now
            };

            var attributes = new List<ProfileAttribute>
            {
                 new ProfileAttribute{ FieldName="Code", Value="8888", VisibilityLevel=VisibilityLevel.Public}
            };

            var result = repository.Save(profile, attributes);
            Assert.AreEqual(true, result, "Save profile error!");
        }

        [Test]
        public void Test_UpdateProfile()
        {
            var profile = repository.GetProfileByAccountId(6);
            Assert.IsNotNull(profile);

            var attributes = new List<ProfileAttribute>
            {
                 new ProfileAttribute{ AttributeId=profile.ProfileId, FieldName="Code", Value="8888", VisibilityLevel=VisibilityLevel.Public}
            };

            var result = repository.Save(profile, attributes);
            Assert.AreEqual(true, result);


        }

        [Test]
        public void Test_GetProfileByAccountId()
        {
            var profile = repository.GetProfileByAccountId(6);
            Assert.IsNotNull(profile);
            Assert.Greater(profile.ProfileId, 0);
        }

        [Test]
        public void Test_GetProfileAttributesByProfile()
        {
            var attributes = repository.GetProfileAttributesByProfile(5);
            Assert.IsNotNull(attributes);
            Assert.Greater(attributes.Count, 0);

        }
    }
}
