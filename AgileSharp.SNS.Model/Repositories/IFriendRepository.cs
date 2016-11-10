using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IFriendRepository
    {     
        bool Save(Friend friend);
        bool DeleteFriendFor(int accountMater, int friendId);

        List<Friend> GetFriendsByAccountId(int accountId, int startIndex, int requestSize, ref int totalCount);
    }
}
