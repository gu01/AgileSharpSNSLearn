using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using AutoMapper;

namespace AgileSharp.SNS.Repository.Mappings
{
    public static class TermMapping
    {
        public static Term ToModel(this tb_Term dataEntity)
        {
            Term account = null;
            if (dataEntity != null)
            {
                account = new Term
                {
                    TermId = dataEntity.TermId,
                    Name = dataEntity.Name,
                    LastUpdateDate = dataEntity.LastUpdateDate,
                    CreateDate = dataEntity.CreateDate.Value,
                    Version = dataEntity.Version
                };
            }
            return account;
        }


        public static List<Term> ToModels(this List<tb_Term> entities)
        {
            List<Term> result = new List<Term>();
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

        public static tb_Term ToDataEntity(this  Term model)
        {
            tb_Term dataEntity = null;
            if (model != null)
            {
                dataEntity = new tb_Term
                {
                    TermId = model.TermId,
                    Name = model.Name,
                    Terms = model.TermContent,
                    LastUpdateDate = model.LastUpdateDate,
                    CreateDate = model.CreateDate,
                    Version = model.Version
                };
            }
            return dataEntity;
        }
    }
}
