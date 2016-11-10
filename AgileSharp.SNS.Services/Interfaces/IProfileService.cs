using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IProfileService
    {
        bool SaveProfile(ProfileRequest request);
        ProfileResponse GetProfileByAccountId(int accountId);
        ProfileResponse GetAttributeByProfileId(int profileId);
    }
}
