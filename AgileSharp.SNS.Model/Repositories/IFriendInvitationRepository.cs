using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IFriendInvitationRepository
    {
        FriendInvitation GetFriendInvitationByIdentity(Guid identity);
        void ClearUpFriendInvitationFor(int accountId);
        bool SaveFriendInvitation(FriendInvitation invitation);     
    }
}
