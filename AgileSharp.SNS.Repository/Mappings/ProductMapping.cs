using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Repository.Mappings
{
    public static class ProductMapping
    {
        public static Product ToModel(this tb_Product dataEntity)
        {
            Product result = null;
            if (dataEntity != null)
            {
                result = new Product();
                result.ProductId = dataEntity.ProductId;
                result.Name = dataEntity.Name;
                result.Description = dataEntity.Description;
                result.CategoryId = dataEntity.CategoryId;
                result.Icon = dataEntity.Icon;
                result.DetailImage = dataEntity.DetailImage;
                result.ViewCount = dataEntity.ViewCount.Value;
                result.DownloadCount = dataEntity.DownloadCount.Value;
                result.IsHot = dataEntity.IsHot.Value;
                result.IsRecommend = dataEntity.IsRecommend.Value;
                result.IsDeleted = dataEntity.IsDeleted.Value;
                result.CreateDate = dataEntity.CreateDate.Value;
            }

            return result;
        }

        public static List<Product> ToModels(this List<tb_Product> dataEntityList)
        {
            List<Product> result = new List<Product>();
            if (dataEntityList != null && dataEntityList.Count > 0)
            {
                foreach (var data in dataEntityList)
                {
                    result.Add(data.ToModel());
                }
            }

            return result;
        }

        public static tb_Product ToDataEntity(this Product model)
        {
            tb_Product result = null;
            if (model != null)
            {
                result = new tb_Product();
                result.ProductId = model.ProductId;
                result.Name = model.Name;
                result.Description = model.Description;
                result.CategoryId = model.CategoryId;
                result.Icon = model.Icon;
                result.DetailImage = model.DetailImage;
                result.ViewCount = model.ViewCount;
                result.DownloadCount = model.DownloadCount;
                result.IsHot = model.IsHot;
                result.IsRecommend = model.IsRecommend;
                result.IsDeleted = model.IsDeleted;
                result.CreateDate = model.CreateDate;
                result.LastUpdateDate = model.LastUpdateDate;
                result.AccountId = model.AccountId;
            }

            return result;
        }

        public static ProductAttribute ToModel(this tb_ProductAttribute dataEntity)
        {
            return null;
        }

        public static List<ProductAttribute> ToModels(this List<tb_ProductAttribute> dataEntityList)
        {
            return null;
        }

        public static List<tb_ProductAttribute> ToDataEntities(this List<ProductAttribute> models)
        {
            return null;
        }
    }
}
