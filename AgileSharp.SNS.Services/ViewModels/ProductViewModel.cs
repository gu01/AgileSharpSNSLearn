using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategorId { get; set; }
        public string Icon { get; set; }
        public string DetailImage { get; set; }

        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
        public bool IsHot { get; set; }
        public bool IsRecommend { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime LastUpdatDate { get; set; }
        public Binary Version { get; set; }

        public virtual List<ProductAttributeViewModel> Attributes { get; set; }
    }
}
