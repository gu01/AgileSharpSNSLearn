using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using AutoMapper;

namespace AgileSharp.SNS.Repository.Mappings
{
    public static class AccountMapping
    {
        public static Account ToModel(this tb_Account dataEntity)
        {
            Account account = null;
            if (dataEntity != null)
            {
                account = new Account
                {
                    AccountId = dataEntity.AccountId,
                    Username = dataEntity.Username,
                    Password = dataEntity.Password,
                    Email = dataEntity.Email,
                    EmailVerfied = dataEntity.EmailVerfied,
                    CreateDate = dataEntity.CreateDate.Value,
                    IsDeleted = dataEntity.IsDeleted.Value,
                    LastUpdateDate = dataEntity.LastUpdateDate.Value,
                    Version = dataEntity.Version,
                    TermId = dataEntity.TermId,
                    AgreedToTermsDate = dataEntity.AgreedToTermsDate.Value
                };
            }
            return account;
        }


        public static List<Account> ToModels(this List<tb_Account> entities)
        {
            List<Account> result = new List<Account>();
            if (entities != null && entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    var model = entity.ToModel();
                    if (model != null)
                    {
                        result.Add(model);
                    }
                }
            }
            return result;
        }

        public static tb_Account ToDataEntity(this  Account model)
        {
            tb_Account dataEntity = null;
            if (model != null)
            {
                dataEntity = new tb_Account
                {
                    AccountId = model.AccountId,
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    EmailVerfied = model.EmailVerfied,
                    IsDeleted = model.IsDeleted,
                    Version = model.Version,
                    TermId = model.TermId,
                    CreateDate = model.CreateDate,
                    LastUpdateDate = model.LastUpdateDate,
                    AgreedToTermsDate = model.AgreedToTermsDate
                };
            }
            return dataEntity;
        }
    }
}
