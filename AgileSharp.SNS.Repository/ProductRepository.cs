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
namespace AgileSharp.SNS.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool SaveProduct(Product product, List<ProductAttribute> attributes)
        {
            bool result = true;
            if (product != null)
            {
                try
                {
                    using (var context = new AgileSharpSNSDataContext())
                    {
                        var entity = product.ToDataEntity();
                        if (product.ProductId > 0)
                        {
                            entity.LastUpdateDate = DateTime.Now;
                            context.tb_Products.Attach(entity, true);
                            context.SubmitChanges();
                        }
                        else
                        {
                            entity.LastUpdateDate = DateTime.Now;
                            entity.CreateDate = DateTime.Now;
                            context.tb_Products.InsertOnSubmit(entity);
                            context.SubmitChanges();
                        }

                        if (attributes != null && attributes.Count > 0)
                        {
                            var existsAttributes = context.tb_ProductAttributes.
                                Where(u => u.ProductId == entity.ProductId).ToList();

                            context.tb_ProductAttributes.DeleteAllOnSubmit(existsAttributes);
                            context.SubmitChanges();

                            var attributeEntities = attributes.ToDataEntities();
                            foreach (var a in attributeEntities)
                            {
                                a.ProductId = entity.ProductId;
                                a.CreateDate = DateTime.Now;
                            }
                            context.tb_ProductAttributes.InsertAllOnSubmit(attributeEntities);
                            context.SubmitChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    ObjectFactory.GetInstance<ILogger>().Error(this, "Save product", ex);
                }
            }

            return result;
        }

        public bool Delete(int productId)
        {
            bool result = false;
            if (productId > 0)
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var product = (from p in context.tb_Products
                                   where p.ProductId == productId && p.IsDeleted == false
                                   select p
                                     ).FirstOrDefault();
                    if (product != null)
                    {
                        product.IsDeleted = true;
                        context.tb_Products.Attach(product, true);
                        context.SubmitChanges();
                        result = true;
                    }
                }
            }
            return result;
        }

        public Product GetProductById(int productId)
        {
            Product result = null;
            if (productId > 0)
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var product = (from p in context.tb_Products
                                   where p.ProductId == productId && p.IsDeleted == false
                                   select p
                                     ).FirstOrDefault();
                    if (product != null)
                    {
                        product.ViewCount++;
                        context.tb_Products.Attach(product, true);
                        context.SubmitChanges();
                        result = product.ToModel();
                    }
                }
            }
            return result;
        }

        public List<Product> GetHotProducts(int startIndex, int pageSize, ref int totalCount)
        {
            List<Product> result = new List<Product>();

            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var products = from p in context.tb_Products
                               where p.IsDeleted == false && p.IsHot.Value
                               select p;
                totalCount = products.Count();
                result = products.Skip(startIndex).Take(pageSize).ToList().ToModels();

            }
            return result;
        }

        public List<Product> GetRecommendProducts(int startIndex, int pageSize, ref int totalCount)
        {
            List<Product> result = new List<Product>();

            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                var products = from p in context.tb_Products
                               where p.IsDeleted == false && p.IsRecommend.Value
                               select p;
                totalCount = products.Count();
                result = products.Skip(startIndex).Take(pageSize).ToList().ToModels();

            }
            return result;
        }

        public List<Product> GetAllProducts(string queryString, int startIndex, int requestCount, ref int totalCount)
        {
            List<Product> result = new List<Product>();
            using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
            {
                if (queryString.IsNotEmpty())
                {
                    var entities = (from p in context.tb_Products
                                    where p.Name.Contains(queryString) &&
                                        p.IsDeleted == false
                                    select p);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                }
                else
                {
                    var entities = (from p in context.tb_Products
                                    where p.IsDeleted == false
                                    select p);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                }
            }
            return result;
        }

        public List<Product> GetProductsByCategoryId(int categoryId, int startIndex, int requestCount, ref int totalCount)
        {
            List<Product> result = new List<Product>();
            if (categoryId > 0)
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var entities = (from p in context.tb_Products
                                    where p.CategoryId == categoryId &&
                                        p.IsDeleted == false
                                    select p);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();


                }
            }
            return result;
        }

        public List<Product> GetProductsByCategoryName(string categoryName, int startIndex, int requestCount, ref int totalCount)
        {
            List<Product> result = new List<Product>();
            if (categoryName.IsNotEmpty())
            {
                using (AgileSharpSNSDataContext context = new AgileSharpSNSDataContext())
                {
                    var entities = (from p in context.tb_Products
                                    where p.tb_ProductCategory.Name.Contains(categoryName) &&
                                        p.IsDeleted == false
                                    select p);
                    totalCount = entities.Count();
                    result = entities.Skip(startIndex).Take(requestCount).ToList().ToModels();
                }
            }
            return result;
        }

        public List<ProductAttribute> GetAttributesByProductId(int productId)
        {
            List<ProductAttribute> result = new List<ProductAttribute>();
            if (productId > 0)
            {
                using (var context = new AgileSharpSNSDataContext())
                {
                    var attributes = (from a in context.tb_ProductAttributes
                                      where a.ProductId == productId
                                      select a).ToList();
                    result = attributes.ToModels();
                }
            }
            return result;
        }
               
    }
}
