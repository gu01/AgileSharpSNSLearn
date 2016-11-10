using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Repository.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(this tb_ProductCategory dataEntity)
        {
            Category result = null;
            if (dataEntity != null)
            {
                result = new Category();
                result.Name = dataEntity.Name;
                result.CategoryId = dataEntity.CategoryId;
                result.ViewCount = dataEntity.ViewCount.Value;
                result.IsDeleted = dataEntity.IsDeleted.Value;
                result.CreateDate = dataEntity.CreateDate.Value;
                result.ParentId = dataEntity.ParentId.Value;
                result.LastUpdateDate = dataEntity.LastUpdateDate.Value;
                result.Version = dataEntity.Version;
            }

            return result;
        }


        public static List<Category> ToModels(this List<tb_ProductCategory> entities)
        {
            List<Category> result = new List<Category>();
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

        public static tb_ProductCategory ToDataEntity(this  Category model)
        {
            tb_ProductCategory result = null;
            if (model != null)
            {
                result = new tb_ProductCategory();
                result.Name = model.Name;
                result.CategoryId = model.CategoryId;
                result.ViewCount = model.ViewCount;
                result.IsDeleted = model.IsDeleted;
                result.CreateDate = model.CreateDate;
                result.ParentId = model.ParentId;
                result.LastUpdateDate = model.LastUpdateDate;
                result.Version = model.Version;
            }

            return result;
        }

    }
}
