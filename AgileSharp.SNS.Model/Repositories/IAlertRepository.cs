using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IAlertRepository
    {
        List<Alert> GetAlertsByAccountId(int accountId);
        void Save(Alert alert);
        void Delete(int alertId);
    }
}
