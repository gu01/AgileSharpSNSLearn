using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class SaveProductRequest
    {
        public ProductViewModel ProductInfo{get;set;}
        public List<ProductAttributeViewModel> Attributes { get; set; }
    }
}
