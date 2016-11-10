using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IProductService
    {
        bool SaveProduct(SaveProductRequest request);
        bool Delete(int productId);
        ProductViewModel GetProductById(int productId);
        ProductResponse GetAttributesByProductId(int productId);

        ProductResponse GetHotProducts(SearchProductRequest request);
        ProductResponse GetRecommendProducts(SearchProductRequest request);
        ProductResponse GetAllProducts(SearchProductRequest request);
        ProductResponse GetProductsByCategoryId(SearchProductRequest request);
        ProductResponse GetProductsByCategoryName(SearchProductRequest request);


        bool SaveCategory(CategoryViewModel category);
        bool DeleteCategory(int categoryId);
        CategoryResponse GetAllCategories();
        CategoryViewModel GetCategoryById(int categoryId);
        CategoryViewModel GetCategoryByName(string categoryName);

        DownloadTrackViewModel GetTrackInfoByProductId(int productId);
        void SaveProductTrack(DownloadTrackRequest request);

        DownloadTrackResponse GetTopNTracksByType(DownloadTrackRequest request);
       
    }
}
