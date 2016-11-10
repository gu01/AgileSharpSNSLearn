using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using System.Linq.Expressions;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IAccountRepository
    {
        Account GetAccountById(int accountId);
        Account GetAccountByEmail(string email);
        Account GetAccountByUsername(string username);

        bool Save(Account account);
        bool AddPermission(int accountId, int permissionId);
        bool Delete(int accountId);

        List<Account> GetAllAccounts(string queryString, 
            int startIndex, 
            int requestCount, 
            ref int totalCount);

    }
}
