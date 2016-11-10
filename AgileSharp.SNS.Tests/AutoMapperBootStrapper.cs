
using StructureMap;
using StructureMap.Configuration.DSL;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Repository;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Services.Implementation;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Infrastructure.Config;
using AgileSharp.SNS.Infrastructure.Logging;
using AutoMapper;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Tests
{

    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Product Title
            Mapper.CreateMap<Account, AccountViewModel>();
            Mapper.CreateMap<AccountViewModel, Account>();

            Mapper.CreateMap<AgileSharp.SNS.Model.Entities.Profile, ProfileViewModel>();
            Mapper.CreateMap<ProfileViewModel, AgileSharp.SNS.Model.Entities.Profile>();

            Mapper.CreateMap<ProfileAttribute, ProfileAttributeViewModel>();
            Mapper.CreateMap<ProfileAttributeViewModel, ProfileAttribute>()
                .ForMember(a => a.VisibilityLevel, ar => ar.ResolveUsing<ProfileAttributeLevelResolver>());
            //Mapper.CreateMap<Order, OrderSummaryView>()
            //    .ForMember(o => o.IsSubmitted,
            //               ov => ov.ResolveUsing<OrderStatusResolver>());


            //// Global Money Formatter
            //Mapper.AddFormatter<MoneyFormatter>();

        }
    }

    public class ProfileAttributeLevelResolver : ValueResolver<ProfileAttributeViewModel, int>
    {
        protected override int ResolveCore(ProfileAttributeViewModel source)
        {
            return (int)source.VisibilityLevel;
        }
    }


    ////public class MoneyFormatter : IValueFormatter
    ////{
    ////    public string FormatValue(ResolutionContext context)
    ////    {
    ////        if (context.SourceValue is decimal)
    ////        {
    ////            decimal money = (decimal)context.SourceValue;

    ////            return money.FormatMoney();
    ////        }

    ////        return context.SourceValue.ToString();
    ////    }
    ////}

}
