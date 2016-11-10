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
    public class AccountGradeRepository : IAccountGradeRepository
    {
        public AccountGrade GetAccountGradeByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }

        public bool SaveMonthTrack(int accountId, int monthCount)
        {
            throw new NotImplementedException();
        }

        public List<AccountGrade> GetTopTotalGrade(int requestCount)
        {
            throw new NotImplementedException();
        }

        public List<AccountGrade> GetTopMonthGrade(int requestCount)
        {
            throw new NotImplementedException();
        }
    }
}
