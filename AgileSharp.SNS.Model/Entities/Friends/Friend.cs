using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Friend
    {
        public int FriendId { get; set; }
        public int AccountId { get; set; }
        public int MyFriendsAccountId { get; set; }
        public DateTime CreateDate { get; set; }       
        public Binary Version { get; set; }
        public bool IsDeleted { get; set; }
    }
}
