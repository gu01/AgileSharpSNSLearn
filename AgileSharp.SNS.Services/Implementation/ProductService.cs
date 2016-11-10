using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.Interfaces;
using AgileSharp.SNS.Model;
using AgileSharp.SNS.Model.Repositories;
using AgileSharp.SNS.Infrastructure.Email;
using AgileSharp.SNS.Infrastructure;
using AgileSharp.SNS.Model.Entities;
using StructureMap;
using AgileSharp.SNS.Infrastructure.Config;
using AgileSharp.SNS.Services.Authenticate;
using AgileSharp.SNS.Services.Messages;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Services.Mappings;
using AgileSharp.SNS.Infrastructure.Logging;

namespace AgileSharp.SNS.Services.Implementation
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private IDownloadTrackRepository downloadTrackRepository;
        private ICategoryRepository categoryRepository;

        public ProductService()
        {
            productRepository = ObjectFactory.GetInstance<IProductRepository>();
            downloadTrackRepository = ObjectFactory.GetInstance<IDownloadTrackRepository>();
            categoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
        }

        #region IProductService Members

        public bool SaveProduct(SaveProductRequest request)
        {
            bool result = false;
            if (request != null)
            {
                result = productRepository.SaveProduct
                    (request.ProductInfo.ToModel(), request.Attributes.ToModels());
            }
            return result;
        }

        public bool Delete(int productId)
        {
            bool result = false;
            if (productId > 0)
            {
                result = productRepository.Delete(productId);
            }
            return result;
        }

        public ProductViewModel GetProductById(int productId)
        {
            ProductViewModel result = null;
            if (productId > 0)
            {
                var product = productRepository.GetProductById(productId);
                if (product != null)
                {
                    result = product.ToViewModel();
                    if (product.Attributes != null && product.Attributes.Count > 0)
                    {
                        result.Attributes = product.Attributes.ToViewModels();
                    }
                }
            }
            return result;
        }

        public ProductResponse GetAttributesByProductId(int productId)
        {
            ProductResponse result = new ProductResponse();
            if (productId > 0)
            {
                var attributes = productRepository.GetAttributesByProductId(productId);
                if (attributes != null && attributes.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Attributes = attributes.ToViewModels();
                }
            }
            return result;
        }

        public ProductResponse GetHotProducts(SearchProductRequest request)
        {
            ProductResponse result = new ProductResponse();
            if (request != null)
            {
                int totalCount = 0;
                var products = productRepository.GetHotProducts(request.StartIndex, request.RequestCount, ref totalCount);
                if (products != null && products.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Products = products.ToViewModels();
                    result.TotalCount = totalCount;
                }
            }
            return result;
        }

        public ProductResponse GetRecommendProducts(SearchProductRequest request)
        {
            ProductResponse result = new ProductResponse();
            if (request != null)
            {
                int totalCount = 0;
                var products = productRepository.GetRecommendProducts(request.StartIndex, request.RequestCount, ref totalCount);
                if (products != null && products.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Products = products.ToViewModels();
                    result.TotalCount = totalCount;
                }
            }
            return result;
        }

        public ProductResponse GetAllProducts(SearchProductRequest request)
        {
            ProductResponse result = new ProductResponse();
            if (request != null)
            {
                int totalCount = 0;
                var products = productRepository.GetAllProducts(request.QueryString,
                    request.StartIndex, request.RequestCount, ref totalCount);
                if (products != null && products.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Products = products.ToViewModels();
                    result.TotalCount = totalCount;
                }
            }
            return result;
        }

        public ProductResponse GetProductsByCategoryId(SearchProductRequest request)
        {
            ProductResponse result = new ProductResponse();
            if (request != null)
            {
                int totalCount = 0;
                var products = productRepository.GetProductsByCategoryId(request.CategoryId,
                    request.StartIndex, request.RequestCount, ref totalCount);
                if (products != null && products.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Products = products.ToViewModels();
                    result.TotalCount = totalCount;
                }
            }
            return result;
        }

        public ProductResponse GetProductsByCategoryName(SearchProductRequest request)
        {
            ProductResponse result = new ProductResponse();
            if (request != null)
            {
                int totalCount = 0;
                var products = productRepository.GetProductsByCategoryName(request.QueryString,
                    request.StartIndex, request.RequestCount, ref totalCount);
                if (products != null && products.Count > 0)
                {
                    result.IsSuccess = true;
                    result.Products = products.ToViewModels();
                    result.TotalCount = totalCount;
                }
            }
            return result;
        }

        public bool SaveCategory(CategoryViewModel category)
        {
            bool result = false;
            if (category != null)
            {
                result = categoryRepository.Save(category.ToModel());
            }
            return result;
        }

        public bool DeleteCategory(int categoryId)
        {
            bool result = false;
            if (categoryId > 0)
            {
                result = categoryRepository.Delete(categoryId);
            }
            return result;
        }

        public CategoryResponse GetAllCategories()
        {
            CategoryResponse result = new CategoryResponse();
            var categories = categoryRepository.GetAllCategories();
            if (categories != null && categories.Count > 0)
            {
                result.IsSuccess = true;
                result.Categories = categories.ToViewModels();
            }
            return result;
        }

        public CategoryViewModel GetCategoryById(int categoryId)
        {
            CategoryViewModel result = null;
            if (categoryId > 0)
            {
                var category = categoryRepository.GetCategoryById(categoryId);
                if (category != null)
                {
                    result = category.ToViewModel();
                }
            }
            return result;
        }

        public CategoryViewModel GetCategoryByName(string categoryName)
        {
            CategoryViewModel result = null;
            if (categoryName.IsNotEmpty())
            {
                var category = categoryRepository.GetCategoryByName(categoryName);
                if (category != null)
                {
                    result = category.ToViewModel();
                }
            }
            return result;
        }

        public DownloadTrackViewModel GetTrackInfoByProductId(int productId)
        {
            DownloadTrackViewModel result = null;
            if (productId > 0)
            {
                var data = downloadTrackRepository.GetTrackInfoByProductId(productId);
                if (data != null)
                {
                    result = data.ToViewModel();
                }
            }
            return result;
        }

        public void SaveProductTrack(DownloadTrackRequest request)
        {
            if (request != null)
            {
                switch (request.TrackType)
                {
                    case DownloadTrackType.Daily:
                        downloadTrackRepository.SaveDailyTrack(request.ProductId, 1);
                        break;
                    case DownloadTrackType.Weekly:
                        downloadTrackRepository.SaveWeeklyTrack(request.ProductId, 1);
                        break;
                    case DownloadTrackType.Month:
                        downloadTrackRepository.SaveMonthTrack(request.ProductId, 1);
                        break;
                }
            }
        }

        public DownloadTrackResponse GetTopNTracksByType(DownloadTrackRequest request)
        {
            DownloadTrackResponse result = new DownloadTrackResponse();
            if (request != null)
            {
                List<DownloadTrack> tracks = null;

                switch (request.TrackType)
                {
                    case DownloadTrackType.Daily:
                        tracks = downloadTrackRepository.GetDailyTopTracks(request.RequestCount);
                        break;
                    case DownloadTrackType.Weekly:
                        tracks = downloadTrackRepository.GetWeeklyTopTracks(request.RequestCount);
                        break;
                    case DownloadTrackType.Month:
                        tracks = downloadTrackRepository.GetMonthTopTracks(request.RequestCount);
                        break;
                    case DownloadTrackType.All:
                        tracks = downloadTrackRepository.GetTotalTopTracks(request.RequestCount);
                        break;
                }

                if (tracks != null && tracks.Count > 0)
                {
                    result.IsSuccess = true;
                    result.DownloadTracks = tracks.ToViewModels();
                }
            }
            return result;
        }

        #endregion
    }
}
