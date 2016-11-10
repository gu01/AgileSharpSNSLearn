
using StructureMap;
using StructureMap.Configuration.DSL;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Repository;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Services.Implementation;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Infrastructure.Config;
using AgileSharp.SNS.Infrastructure.Logging;

namespace AgileSharp.SNS.Tests
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                // Repositories 
                ForRequestedType<IAccountRepository>().AsSingletons().TheDefault.Is.OfConcreteType<AccountRepository>();
                ForRequestedType<IAccountGradeRepository>().AsSingletons().TheDefault.Is.OfConcreteType<AccountGradeRepository>();
                ForRequestedType<IAccountService>().AsSingletons().TheDefault.Is.OfConcreteType<AccountService>();

                ForRequestedType<IEmail>().AsSingletons().TheDefault.Is.OfConcreteType<EmailService>();
                ForRequestedType<IConfiguration>().AsSingletons().TheDefault.Is.OfConcreteType<Configuration>();
                ForRequestedType<ILogger>().AsSingletons().TheDefault.Is.OfConcreteType<DefaultLogger>();

                ForRequestedType<ITermRepository>().AsSingletons().TheDefault.Is.OfConcreteType<TermRepository>();
                ForRequestedType<IProductRepository>().AsSingletons().TheDefault.Is.OfConcreteType<ProductRepository>();

                ForRequestedType<IProfileRepository>().AsSingletons().TheDefault.Is.OfConcreteType<ProfileRepository>();
                ForRequestedType<IProfileService>().AsSingletons().TheDefault.Is.OfConcreteType<ProfileService>();
            }
        }
    }
}
