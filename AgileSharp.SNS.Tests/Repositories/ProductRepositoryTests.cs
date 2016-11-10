using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileSharp.SNS.Model.Repositories;
using StructureMap;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Tests.Repositories
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        IProductRepository repository = null;

        [SetUp]
        public void Init()
        {
            BootStrapper.ConfigureDependencies();
            repository = ObjectFactory.GetInstance<IProductRepository>();
        }

        [Test]
        public void Test_SaveProduct()
        {
            var product = new Product();
            product.Name = "软件";
            product.CategoryId = 1;
            product.Icon = "Icon";
            product.AccountId = 6;
            product.DetailImage = "DetailImage";
            product.Description = "test";
            var result = repository.SaveProduct(product, null);
            Assert.AreEqual(true, result, "Save Product Failed");
        }

        public void Test_DeleteProduct()
        {
            var result = repository.Delete(7);
            Assert.AreEqual(true, result);
        }

    }
}
