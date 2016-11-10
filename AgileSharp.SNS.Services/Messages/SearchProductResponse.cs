using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class ProductResponse : ResponseBase
    {
        public List<ProductViewModel> Products { get; set; }
        public List<ProductAttributeViewModel> Attributes { get; set; }
        public int TotalCount { get; set; }
    }
}
