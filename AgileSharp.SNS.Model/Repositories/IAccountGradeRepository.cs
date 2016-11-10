using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IAccountGradeRepository
    {
        AccountGrade GetAccountGradeByAccountId(int accountId);
        bool SaveMonthTrack(int accountId, int monthCount);
        List<AccountGrade> GetTopTotalGrade(int requestCount);
        List<AccountGrade> GetTopMonthGrade(int requestCount);
    }
}
