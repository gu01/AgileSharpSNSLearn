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
    public class CategoryRepository : ICategoryRepository
    {
        #region ICategoryRepository Members

        public bool Save(Category category)
        {
            bool result = false;
            if (category != null)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var entity = category.ToDataEntity();
                    if (category.CategoryId > 0)
                    {
                        entity.LastUpdateDate = DateTime.Now;
                        context.tb_ProductCategories.Attach(entity, true);
                    }
                    else
                    {
                        entity.LastUpdateDate = DateTime.Now;
                        entity.CreateDate = DateTime.Now;
                        context.tb_ProductCategories.InsertOnSubmit(entity);
                    }
                    context.SubmitChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool Delete(int categoryId)
        {
            bool result = false;
            if (categoryId > 0)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var entity = (from c in context.tb_ProductCategories
                                  where c.IsDeleted.Value == false &&
                                  c.CategoryId == categoryId
                                  select c).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.IsDeleted = true;
                        context.tb_ProductCategories.Attach(entity, true);
                        context.SubmitChanges();
                        result = true;
                    }
                }
            }
            return result;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> result = null;
            using (var context = new AgileSharpSNSDataContext())
            {
                var entities = (from c in context.tb_ProductCategories
                                where c.IsDeleted.Value == false
                                select c).ToList();
                if (entities != null && entities.Count > 0)
                {
                    result = entities.ToModels();
                }
            }
            return result;
        }

        public Category GetCategoryById(int categoryId)
        {
            Category result = null;
            if (categoryId > 0)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var entity = (from c in context.tb_ProductCategories
                                  where c.IsDeleted.Value == false &&
                                  c.CategoryId == categoryId
                                  select c).FirstOrDefault();
                    if (entity != null)
                    {
                        result = entity.ToModel();
                        result.ProductCount = GetProductCountByCategoryId(context, categoryId);
                    }
                }
            }
            return result;
        }

        public Category GetCategoryByName(string categoryName)
        {
            Category result = null;
            if (categoryName.IsNotEmpty())
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var entity = (from c in context.tb_ProductCategories
                                  where c.IsDeleted.Value == false &&
                                  string.Compare(c.Name, categoryName) == 0
                                  select c).FirstOrDefault();
                    if (entity != null)
                    {
                        result = entity.ToModel();
                        result.ProductCount = GetProductCountByCategoryId(context, entity.CategoryId);
                    }
                }
            }
            return result;
        }

        #endregion

        private long GetProductCountByCategoryId(AgileSharpSNSDataContext context, int categoryId)
        {
            return context.tb_Products.Where(u => u.IsDeleted == false &&
                u.CategoryId == categoryId).Count();

        }
    }
}
