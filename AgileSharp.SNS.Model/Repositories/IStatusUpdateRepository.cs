using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IStatusUpdateRepository
    {
        bool AddStatusUpdate(StatusUpdate status);
        List<StatusUpdate> GetTopNStatusUpdatesByAccountId(int accountId, int reqestSize);
    }
}
