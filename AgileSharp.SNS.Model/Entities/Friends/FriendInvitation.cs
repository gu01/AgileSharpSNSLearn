using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class FriendInvitation
    {
        public int InvitationId { get; set; }
        public int AccountId { get; set; }
        public string Email { get; set; }
        public Guid InvitationIdentity { get; set; }
        public DateTime CreateDate { get; set; }
        public int BecameAccountId { get; set; }
        public Binary Version { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsAccepted
        {
            get
            {
                return BecameAccountId > 0;
            }
        }
    }
}
