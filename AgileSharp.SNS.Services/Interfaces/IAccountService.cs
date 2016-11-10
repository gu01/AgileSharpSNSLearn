using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities; 
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IAccountService
    {
        bool DeleteAccount(AccountViewModel account);
        bool UsernameInUse(string username);
        bool EmailInUse(string email);
        LoginResponse Login(LoginRequest request);
        RegisterResponse Register(RegisterRequest request);
        bool ActiveAccount(string activeKey); 

        bool RecoverPassword(string email);
        bool SaveAccount(AccountViewModel account);
       
        SearchAccountResponse Search(SearchAccountRequest request);

        //..
        AccountGradeViewModel GetAccountGradeByAccountId(int accountId);
        bool SaveMonthTrack(int accountId, int monthCount);
        AccountGradeResponse GetTopTotalGrade(int requestCount);
        AccountGradeResponse GetTopMonthGrade(int requestCount);
    }
}
