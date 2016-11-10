using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Icon { get; set; }
        public string DetailImage { get; set; }

        public int ViewCount { get; set; }
        public int DownloadCount { get; set; }
        public bool IsHot { get; set; }
        public bool IsRecommend { get; set; }
        public int AccountId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Binary Version { get; set; }

        public List<ProductAttribute> Attributes { get; set; }
    }
}
