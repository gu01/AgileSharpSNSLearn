using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AgileSharp.SNS.Services.ViewModels;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;

namespace AgileSharp.SNS.WebUI.Models
{
    public class ProductViewModelProxy : ProductViewModel
    {
        private List<ProductAttributeViewModel> attributes = null;

        public bool HasLoadAttribute { get; set; }

        public override List<ProductAttributeViewModel> Attributes
        {
            get
            {
                if (!HasLoadAttribute)
                {
                    var response = ObjectFactory.GetInstance<IProductService>().
                        GetAttributesByProductId(base.ProductId);
                    if (response.IsSuccess)
                    {
                        attributes = response.Attributes;
                        HasLoadAttribute = true;
                    }

                }
                return attributes;
            }
            set
            {
                attributes = value;
            }
        }
    }

}
