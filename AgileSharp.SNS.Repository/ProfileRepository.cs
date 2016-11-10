using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Repository.Mappings;
using AgileSharp.SNS.Infrastructure;
using StructureMap;
using AgileSharp.SNS.Infrastructure.Logging;
using System.Transactions;

namespace AgileSharp.SNS.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        public List<ProfileAttribute> GetProfileAttributesByProfile(int profileId)
        {
            List<ProfileAttribute> result = null;
            if (profileId > 0)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var attributes = (from p in context.tb_ProfileAttributes
                                      where p.ProfileId == profileId
                                      select p).ToList();
                    if (attributes != null && attributes.Count > 0)
                    {
                        result = attributes.ToModels();
                    }
                }
            }
            return result;
        }

        public Profile GetProfileByAccountId(int accountId)
        {
            Profile result = null;
            if (accountId > 0)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var profile = (from p in context.tb_Profiles
                                   where p.AccountId == accountId
                                   select p).FirstOrDefault();
                    if (profile != null)
                    {
                        result = profile.ToModel();
                        result.Attributes = profile.tb_ProfileAttributes.ToList().ToModels();
                    }
                }
            }
            return result;
        }

        public bool Save(Profile profile, List<ProfileAttribute> attributes)
        {
            bool result = true;
            if (profile != null)
            {
                try
                {
                    using (var context = new AgileSharpSNSDataContext())
                    {
                        var entity = profile.ToDataEntity();
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (profile.ProfileId > 0)
                            {
                                entity.LastUpdateDate = DateTime.Now;
                                context.tb_Profiles.Attach(entity, true);
                                context.SubmitChanges();
                            }
                            else
                            {
                                entity.LastUpdateDate = DateTime.Now;
                                entity.CreateDate = DateTime.Now;
                                context.tb_Profiles.InsertOnSubmit(entity);
                                context.SubmitChanges();
                            }

                            if (attributes != null && attributes.Count > 0)
                            {
                                var existsAttributes = context.tb_ProfileAttributes.
                                    Where(u => u.ProfileId == entity.ProfileId).ToList();

                                context.tb_ProfileAttributes.DeleteAllOnSubmit(existsAttributes);
                                context.SubmitChanges();

                                var attributeEntities = attributes.ToDataEntities();
                                foreach (var a in attributeEntities)
                                {
                                    a.ProfileId = entity.ProfileId;
                                    a.CreateDate = DateTime.Now;
                                }
                                context.tb_ProfileAttributes.InsertAllOnSubmit(attributeEntities);
                                context.SubmitChanges();
                            }
                            scope.Complete();

                        }
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    ObjectFactory.GetInstance<ILogger>().Error(this, "Save profile", ex);
                }
            }

            return result;
        }
    }
}
