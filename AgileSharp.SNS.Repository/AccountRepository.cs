using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Repository.Mappings;
using AgileSharp.SNS.Infrastructure;

namespace AgileSharp.SNS.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountById(int accountId)
        {
            Account result = null;
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var entity = (from account in context.tb_Accounts
                              where account.AccountId == accountId &&
                             account.IsDeleted == false
                              select account).FirstOrDefault();
                result = entity.ToModel();
            }
            return result;
        }

        public Account GetAccountByEmail(string email)
        {
            Account result = null;
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var entity = (from account in context.tb_Accounts
                              where string.Compare(account.Email, email) == 0 &&
                             account.IsDeleted == false
                              select account).FirstOrDefault();
                result = entity.ToModel();
            }
            return result;
        }

        public Account GetAccountByUsername(string username)
        {
            Account result = null;
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var entity = (from account in context.tb_Accounts
                              where string.Compare(account.Username, username) == 0 &&
                             account.IsDeleted == false
                              select account).FirstOrDefault();
                result = entity.ToModel();
            }
            return result;
        }

        public bool Save(Account account)
        {
            bool result = false;
            if (account != null)
            {
                var dataEntity = account.ToDataEntity();

                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    if (account.AccountId > 0)
                    {
                        dataEntity.LastUpdateDate = DateTime.Now;
                        context.tb_Accounts.Attach(dataEntity, true);
                    }
                    else
                    {
                        dataEntity.LastUpdateDate = DateTime.Now;
                        dataEntity.CreateDate = DateTime.Now;
                        dataEntity.AgreedToTermsDate = DateTime.Now;
                        context.tb_Accounts.InsertOnSubmit(dataEntity);

                    }
                    context.SubmitChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool AddPermission(int accountId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int accountId)
        {
            bool result = false;
            if (accountId > 0)
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var entity = (from account in context.tb_Accounts
                                  where account.AccountId == accountId &&
                                 account.IsDeleted == false
                                  select account).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.IsDeleted = true;
                    }
                    context.tb_Accounts.Attach(entity, true);
                    context.SubmitChanges();
                    result = true;
                }
            }
            return result;
        }

        public List<Account> GetAllAccounts(string queryString, int startIndex, int requestCount, ref int totalCount)
        {
            List<Account> result = new List<Account>();
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                if (queryString.IsNotEmpty())
                {
                    var entities = (from account in context.tb_Accounts
                                    where (account.Username.Contains(queryString) ||
                                    account.Email.Contains(queryString)) &&
                                        account.IsDeleted == false
                                    select account);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                }
                else
                {
                    var entities = (from account in context.tb_Accounts
                                    where account.IsDeleted == false
                                    select account);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                }
            }
            return result;
        }
    }
}
