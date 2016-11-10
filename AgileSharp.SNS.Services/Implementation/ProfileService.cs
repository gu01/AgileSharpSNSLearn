using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Model.Repositories;
using StructureMap;
using AgileSharp.SNS.Services.Mappings;

namespace AgileSharp.SNS.Services.Implementation
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository profileRepository = null;

        public ProfileService()
        {
            profileRepository = ObjectFactory.GetInstance<IProfileRepository>();
        }

        #region IProfileService Members

        public bool SaveProfile(ProfileRequest request)
        {
            bool result = false;
            if (request != null && request.ProfileInfo != null)
            {
                result = profileRepository.Save(request.ProfileInfo.ToModel(), request.Attributes.ToModels());
            }
            return result;
        }

        public ProfileResponse GetProfileByAccountId(int accountId)
        {
            ProfileResponse result = new ProfileResponse();
            if (accountId > 0)
            {
                var profile = profileRepository.GetProfileByAccountId(accountId);
                if (profile != null)
                {
                    result.ProfileInfo = profile.ToViewModel();                   
                    if (profile.Attributes != null && profile.Attributes.Count > 0)
                    {
                        result.IsSuccess = true;
                        result.Attributes = profile.Attributes.ToViewModels();
                    }                   
                }
            }
            return result;
        }

        public ProfileResponse GetAttributeByProfileId(int profileId)
        {
            ProfileResponse result = new ProfileResponse();
            if (profileId > 0)
            {
                var attributes = profileRepository.GetProfileAttributesByProfile(profileId);
                if (attributes != null && attributes.Count > 0)
                {
                    result.Attributes = attributes.ToViewModels();
                    result.IsSuccess = true;
                }
            }
            return result;
        }

        #endregion
    }
}
