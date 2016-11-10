using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Services.ViewModels;
using AutoMapper;

namespace AgileSharp.SNS.Services.Mappings
{
    public static class ProfileMapper
    {
        public static AgileSharp.SNS.Model.Entities.Profile ToModel(this ProfileViewModel viewModel)
        {
            return Mapper.Map<ProfileViewModel, AgileSharp.SNS.Model.Entities.Profile>(viewModel);
        }

        public static ProfileViewModel ToViewModel(this AgileSharp.SNS.Model.Entities.Profile profile)
        {
            return Mapper.Map<AgileSharp.SNS.Model.Entities.Profile, ProfileViewModel>(profile);
        }

        public static ProfileAttributeViewModel ToViewModel(this ProfileAttribute attribute)
        {
            return Mapper.Map<ProfileAttribute, ProfileAttributeViewModel>(attribute);
        }

        public static List<ProfileAttributeViewModel> ToViewModels(this List<ProfileAttribute> attributes)
        {
            List<ProfileAttributeViewModel> result = null;
            if (attributes != null && attributes.Count > 0)
            {
                result = new List<ProfileAttributeViewModel>();
                foreach (var attribute in attributes)
                {
                    result.Add(attribute.ToViewModel());
                }
            }

            return result;
        }

        public static ProfileAttribute ToModel(this ProfileAttributeViewModel attribute)
        {
            return Mapper.Map<ProfileAttributeViewModel, ProfileAttribute>(attribute);
        }

        public static List<ProfileAttribute> ToModels(this List<ProfileAttributeViewModel> attributes)
        {
            List<ProfileAttribute> result = null;
            if (attributes != null && attributes.Count > 0)
            {
                result = new List<ProfileAttribute>();
                foreach (var attribute in attributes)
                {
                    result.Add(attribute.ToModel());
                }
            }

            return result;
        }
    }
}
