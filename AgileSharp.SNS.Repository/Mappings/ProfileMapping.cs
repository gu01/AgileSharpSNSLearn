using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Repository.Mappings
{
    public static class ProfileMapping
    {
        public static Profile ToModel(this tb_Profile dataEntity)
        {
            Profile result = null;
            if (dataEntity != null)
            {
                result = new Profile
                {
                    ProfileId = dataEntity.ProfileId,
                    ProfileName = dataEntity.ProfileName,
                    Avatar = dataEntity.Avatar,
                    HomePageUrl = dataEntity.HomePageUrl,
                    RealName = dataEntity.RealName,
                    Address = dataEntity.Address,
                    PhoneNumber = dataEntity.PhoneNumber,
                    IM = dataEntity.IMQQ,
                    CreateDate = dataEntity.CreateDate,
                    LastUpdateDate = dataEntity.LastUpdateDate.Value,
                    Version = dataEntity.Version,
                    AccountId = dataEntity.AccountId
                };
            }
            return result;
        }

        public static tb_Profile ToDataEntity(this Profile model)
        {
            tb_Profile result = null;
            if (model != null)
            {
                result = new tb_Profile
                {
                    ProfileId = model.ProfileId,
                    ProfileName = model.ProfileName,
                    Avatar = model.Avatar,
                    HomePageUrl = model.HomePageUrl,
                    RealName = model.RealName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    IMQQ = model.IM,
                    CreateDate = model.CreateDate,
                    LastUpdateDate = model.LastUpdateDate,
                    Version = model.Version,
                    AccountId = model.AccountId
                };
            }
            return result;
        }

        public static ProfileAttribute ToModel(this tb_ProfileAttribute dataEntity)
        {
            ProfileAttribute result = null;
            if (dataEntity != null)
            {
                result = new ProfileAttribute
                {
                    AttributeId = dataEntity.ProfileAttributeId,
                    FieldName = dataEntity.FieldName,
                    Value = dataEntity.Value,
                    VisibilityLevel = (VisibilityLevel)Enum.Parse(typeof(VisibilityLevel), dataEntity.tb_VisibilityLevel.Name),
                    Version = dataEntity.Version,
                     ProfileId=dataEntity.ProfileId
                };
            }
            return result;
        }

        public static tb_ProfileAttribute ToDataEntity(this ProfileAttribute model)
        {
            tb_ProfileAttribute result = null;
            if (model != null)
            {
                result = new tb_ProfileAttribute
                {
                    ProfileAttributeId = model.AttributeId,
                    FieldName = model.FieldName,
                    Value = model.Value,
                    VisibilityLevelId = (int)model.VisibilityLevel,
                    Version = model.Version,
                     ProfileId=model.ProfileId
                };
            }
            return result;
        }

        public static List<tb_ProfileAttribute> ToDataEntities(this List<ProfileAttribute> profiles)
        {
            List<tb_ProfileAttribute> result = new List<tb_ProfileAttribute>();
            if (profiles != null && profiles.Count > 0)
            {
                foreach (var profile in profiles)
                {
                    var model = profile.ToDataEntity();
                    if (model != null)
                    {
                        result.Add(model);
                    }
                }
            }
            return result;
        }

        public static List<ProfileAttribute> ToModels(this List<tb_ProfileAttribute> entities)
        {
            List<ProfileAttribute> result = new List<ProfileAttribute>();
            if (entities != null && entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    var model = entity.ToModel();
                    if (model != null)
                    {
                        result.Add(model);
                    }
                }
            }
            return result;
        }
    }
}
