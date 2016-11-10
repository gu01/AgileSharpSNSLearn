using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Repository.Mappings;
using AgileSharp.SNS.Infrastructure;

namespace AgileSharp.SNS.Repository
{
    public class TermRepository : ITermRepository
    {
        public Term GetCurrentTerm()
        {
            Term result = null;
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var entity = (from term in context.tb_Terms
                              where term.IsCurrentUsed.Value
                              select term).FirstOrDefault();
                result = entity.ToModel();
            }
            return result;
        }

        public bool Save(Term term)
        {
            bool result = false;
            if (term != null)
            {
                var entity = term.ToDataEntity();
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    if (term.TermId > 0)
                    {
                        entity.LastUpdateDate = DateTime.Now;
                        context.tb_Terms.Attach(entity, true);
                    }
                    else
                    {
                        entity.LastUpdateDate = DateTime.Now;
                        entity.CreateDate = DateTime.Now;
                        context.tb_Terms.InsertOnSubmit(entity);
                    }
                    context.SubmitChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool Delete(string termName)
        {
            bool result = false;
            if (termName.IsNotEmpty())
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var entity = (from term in context.tb_Terms
                                  where string.Compare(termName, term.Name) == 0
                                  select term).FirstOrDefault();
                    if (entity != null)
                    {
                        context.tb_Terms.DeleteOnSubmit(entity);
                        context.SubmitChanges();
                        result = true;
                    }
                }
            }
            return result;
        }

        public List<Term> GetAll()
        {
            List<Term> result = null;
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var entities = (from term in context.tb_Terms
                                select term).ToList();
                if (entities != null && entities.Count > 0)
                {
                    result = entities.ToModels();
                }
            }
            return result;
        }

        public string GetTermContentByName(string termName)
        {
            string result = string.Empty;
            if (termName.IsNotEmpty())
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var entity = (from term in context.tb_Terms
                                  where string.Compare(termName, term.Name) == 0
                                  select term).FirstOrDefault();
                    if (entity != null)
                    {
                        result = entity.Terms;
                    }
                }
            }
            return result;
        }
    }
}
