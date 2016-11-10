using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Model;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Infrastructure;
using AgileSharp.SNS.Model.Entities;
using StructureMap;
using AgileSharp.SNS.Infrastructure.Config;
using AgileSharp.SNS.Services.Authenticate;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Services.Mappings;
using AgileSharp.SNS.Infrastructure.Logging;

namespace AgileSharp.SNS.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;
        private IAccountGradeRepository accountGradeRepository;
        private ITermRepository termRepository;
        private ILogger logger;

        public AccountService()
        {
            accountRepository = ObjectFactory.GetInstance<IAccountRepository>();
            accountGradeRepository = ObjectFactory.GetInstance<IAccountGradeRepository>();
            termRepository = ObjectFactory.GetInstance<ITermRepository>();
            logger = ObjectFactory.GetInstance<ILogger>();
        }

        public bool UsernameInUse(string username)
        {
            bool result = false;
            if (username.IsNotEmpty())
            {
                var account = accountRepository.GetAccountByUsername(username);
                if (account != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool EmailInUse(string email)
        {
            bool result = false;
            if (email.IsEmail())
            {
                var account = accountRepository.GetAccountByEmail(email);
                if (account != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse result = new LoginResponse();
            if (request != null && request.Email.IsEmail() 
                && request.Password.IsNotEmpty())
            {
                var authenticateStrategy = 
                    AuthenticateFactory.CreateAuthenticate(request.AuthenticateType);
                result = authenticateStrategy.Validate(request.Email, request.Password);
            }
            return result;
        }

        public bool SaveAccount(AccountViewModel viewModel)
        {
            bool result = false;
            var account = viewModel.ToModel();
            if (account != null)
            {
                if (!account.Username.IsNotEmpty())
                {
                    account.Username = account.Email;
                }
                result = accountRepository.Save(account);
            }
            return result;
        }

        public bool RecoverPassword(string email)
        {
            bool result = false;
            if (email.IsEmail())
            {
                var account = accountRepository.GetAccountByEmail(email);
                if (account != null)
                {
                    account.Password = ServiceHelper.GenerateRandomPassword(account);
                    result = accountRepository.Save(account);
                    ServiceHelper.SendRecoverPasswordEmail(account);
                }
            }
            return result;
        }

        public bool DeleteAccount(AccountViewModel account)
        {
            bool result = false;
            if (account != null && account.AccountId > 0)
            {
                result = accountRepository.Delete(account.AccountId);
            }
            return result;
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            RegisterResponse result = new RegisterResponse();

            if (request != null)
            {
                var isEmailInUse = EmailInUse(request.Email);
                if (isEmailInUse)
                {
                    result.ErrorMessage = "您注册的邮箱已经存在，如果您忘记密码，请使用密码查找功能！";
                }
                else
                {
                    var account = new Account
                    {
                        Email = request.Email,
                        Password = request.Password.Encrypt(request.Email),
                        Username = request.Email,
                        TermId = request.TermId
                    };
                    result.IsSuccess = accountRepository.Save(account);
                    ServiceHelper.SendActiveEmail(account);
                }
            }
            return result;
        }

        public bool ActiveAccount(string activeKey)
        {
            bool result = false;
            try
            {
                if (activeKey.IsNotEmpty())
                {
                    var email = Cryptography.Decrypt(activeKey, "verify");
                    var account = accountRepository.GetAccountByEmail(email);
                    if (account != null)
                    {
                        account.EmailVerfied = true;
                        result = accountRepository.Save(account);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(this, "Active Account Error", ex);
            }

            return result;
        }

        public SearchAccountResponse Search(SearchAccountRequest request)
        {
            SearchAccountResponse result = new SearchAccountResponse();
            if (request != null)
            {
                int total = 0;
                var accounts = accountRepository.
                    GetAllAccounts(request.QueryString,
                    request.StartIndex,
                    request.RequestCount, 
                    ref total);

                if (accounts != null && accounts.Count > 0)
                {
                    result.IsSuccess = true;
                    result.TotalCount = total;
                    result.Accounts = accounts.ToViewModels();
                }
            }

            return result;
        }

        public AccountGradeViewModel GetAccountGradeByAccountId(int accountId)
        {
            AccountGradeViewModel result = null;
            if (accountId > 0)
            {
                var grade = accountGradeRepository.GetAccountGradeByAccountId(accountId);
                if (grade != null)
                {
                    result = grade.ToViewModel();
                }
            }
            return result;
        }

        public bool SaveMonthTrack(int accountId, int monthCount)
        {
            return accountGradeRepository.SaveMonthTrack(accountId, monthCount);
        }

        public AccountGradeResponse GetTopTotalGrade(int requestCount)
        {
            AccountGradeResponse result = new AccountGradeResponse();
            var grades = accountGradeRepository.GetTopTotalGrade(requestCount);
            if (grades != null && grades.Count > 0)
            {
                result.IsSuccess = true;
                result.AccountGrades = grades.ToViewModels();
            }
            return result;
        }

        public AccountGradeResponse GetTopMonthGrade(int requestCount)
        {
            AccountGradeResponse result = new AccountGradeResponse();
            var grades = accountGradeRepository.GetTopMonthGrade(requestCount);
            if (grades != null && grades.Count > 0)
            {
                result.IsSuccess = true;
                result.AccountGrades = grades.ToViewModels();
            }
            return result;
        }
    }
}
