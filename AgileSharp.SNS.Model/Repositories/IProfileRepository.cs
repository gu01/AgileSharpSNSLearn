using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IProfileRepository
    {
        List<ProfileAttribute> GetProfileAttributesByProfile(int profileId);
        Profile GetProfileByAccountId(int accountId);
        bool Save(Profile profile, List<ProfileAttribute> attributes);
    }
}
