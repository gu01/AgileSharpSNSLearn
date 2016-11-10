using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Model.Entities
{
    public enum AlertType
    {
        AccountCreated = 1,
        ProfileCreated = 2,
        AccountModified = 3,
        ProfileModified = 4,
        NewAvatar = 5,
        AddedFriend = 6,
        AddedPicture = 7,
        Vote = 8,
        Comment = 9,
    }
}
