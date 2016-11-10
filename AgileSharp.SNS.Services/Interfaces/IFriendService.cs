using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IFriendService
    {
        bool InviteFriend(Account fromAccount, Account toAccount);

        bool CreateFriend(Friend friend);
        bool DeleteFriendFor(int accountMater, int friendId);
        List<Friend> GetFriendsByAccountId(int accountId, int startIndex, int requestSize, ref int totalCount);

        bool AddStatusUpdateItem(StatusUpdate status);
        List<StatusUpdate> GetTopNStatusUpdatesByAccountId(int accountId, int reqestSize);
    }
}
