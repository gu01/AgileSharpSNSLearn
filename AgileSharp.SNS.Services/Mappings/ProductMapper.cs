using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;
using AgileSharp.SNS.Model.Entities;
using AutoMapper;

namespace AgileSharp.SNS.Services.Mappings
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            return Mapper.Map<Product, ProductViewModel>(product);
        }

        public static Product ToModel(this ProductViewModel viewModel)
        {
            return Mapper.Map<ProductViewModel, Product>(viewModel);
        }

        public static ProductAttributeViewModel ToViewModel(this ProductAttribute attribute)
        {
            return Mapper.Map<ProductAttribute, ProductAttributeViewModel>(attribute);
        }

        public static ProductAttribute ToModel(this ProductAttributeViewModel viewModel)
        {
            return Mapper.Map<ProductAttributeViewModel, ProductAttribute>(viewModel);
        }

        public static List<ProductViewModel> ToViewModels(this List<Product> products)
        {
            List<ProductViewModel> result = null;
            if (products != null && products.Count > 0)
            {
                result = new List<ProductViewModel>();
                foreach (var p in products)
                {
                    result.Add(p.ToViewModel());
                }
            }
            return result;
        }

        public static List<ProductAttribute> ToModels(this List<ProductAttributeViewModel> attributes)
        {
            List<ProductAttribute> result = null;
            if (attributes != null && attributes.Count > 0)
            {
                result = new List<ProductAttribute>();
                foreach (var attribute in attributes)
                {
                    result.Add(attribute.ToModel());
                }
            }

            return result;
        }

        public static List<ProductAttributeViewModel> ToViewModels(this List<ProductAttribute> attributes)
        {
            List<ProductAttributeViewModel> result = null;
            if (attributes != null && attributes.Count > 0)
            {
                result = new List<ProductAttributeViewModel>();
                foreach (var attribute in attributes)
                {
                    result.Add(attribute.ToViewModel());
                }
            }

            return result;
        }

        public static CategoryViewModel ToViewModel(this Category category)
        {
            return Mapper.Map<Category, CategoryViewModel>(category);
        }

        public static Category ToModel(this CategoryViewModel viewModel)
        {
            return Mapper.Map<CategoryViewModel, Category>(viewModel);
        }

        public static List<CategoryViewModel> ToViewModels(this List<Category> categories)
        {
            List<CategoryViewModel> result = null;
            if (categories != null && categories.Count > 0)
            {
                result = new List<CategoryViewModel>();
                foreach (var p in categories)
                {
                    result.Add(p.ToViewModel());
                }
            }
            return result;
        }

        public static DownloadTrackViewModel ToViewModel(this DownloadTrack track)
        {
            return Mapper.Map<DownloadTrack, DownloadTrackViewModel>(track);
        }

        public static DownloadTrack ToModel(this DownloadTrackViewModel viewModel)
        {
            return Mapper.Map<DownloadTrackViewModel, DownloadTrack>(viewModel);
        }

        public static List<DownloadTrackViewModel> ToViewModels(this List<DownloadTrack> tracks)
        {
            List<DownloadTrackViewModel> result = null;
            if (tracks != null && tracks.Count > 0)
            {
                result = new List<DownloadTrackViewModel>();
                foreach (var t in tracks)
                {
                    result.Add(t.ToViewModel());
                }
            }
            return result;
        }
    }
}
