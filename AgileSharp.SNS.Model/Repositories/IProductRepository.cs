using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IProductRepository
    {
        bool SaveProduct(Product product, List<ProductAttribute> attributes);
        bool Delete(int productId);
        Product GetProductById(int productId);

        List<Product> GetHotProducts(int startIndex, int requestCount, ref int totalCount);
        List<Product> GetRecommendProducts(int startIndex, int requestCount, ref int totalCount);
        List<Product> GetAllProducts(string queryString, int startIndex, int requestCount, ref int totalCount);

        List<Product> GetProductsByCategoryId(int categoryId, int startIndex, int requestCount, ref int totalCount);
        List<Product> GetProductsByCategoryName(string categoryName, int startIndex, int requestCount, ref int totalCount);
        List<ProductAttribute> GetAttributesByProductId(int productId);
    }
}
