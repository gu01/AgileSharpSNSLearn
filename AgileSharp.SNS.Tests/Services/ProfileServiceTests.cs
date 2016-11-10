using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Tests.Services
{
    [TestFixture]
    public class ProfileServiceTests
    {
        IProfileService service = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            AutoMapperBootStrapper.ConfigureAutoMapper();
            service = ObjectFactory.GetInstance<IProfileService>();
        }

        [Test]
        public void Test_SaveProfile()
        {
            var request = new ProfileRequest
            {
                ProfileInfo = new ProfileViewModel
                {
                    AccountId = 6,
                    ProfileName = "MyProfile"
                },
                Attributes = new List<ProfileAttributeViewModel>
                {
                     new ProfileAttributeViewModel
                     {
                          FieldName="DetailAddress",
                           Value="Wuhan",
                            VisibilityLevel=VisibilityLevel.Public
                     }
                }

            };

            var result = service.SaveProfile(request);
            Assert.AreEqual(true, result);
        }
    }
}
