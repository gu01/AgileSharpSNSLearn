using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Model.Entities;
using AutoMapper;

namespace AgileSharp.SNS.Services.Mappings
{
    public static class AccountMapper
    {
        public static AccountViewModel ToViewModel(this Account account)
        {
            return Mapper.Map<Account, AccountViewModel>(account);
        }

        public static Account ToModel(this AccountViewModel viewModel)
        {
            return Mapper.Map<AccountViewModel, Account>(viewModel);
        }

        public static List<AccountViewModel> ToViewModels(this List<Account> accounts)
        {
            List<AccountViewModel> result = null;
            if (accounts != null && accounts.Count > 0)
            {
                result = new List<AccountViewModel>();
                foreach (var account in accounts)
                {
                    result.Add(account.ToViewModel());
                }
            }
            return result;
        }
    }
}
