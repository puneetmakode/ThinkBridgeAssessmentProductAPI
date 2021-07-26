using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAdminAPI.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductAdminAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            ProductController obj = new ProductController();
            Task<HttpResponseMessage> result = obj.Get();
            if (result.Result.StatusCode != HttpStatusCode.OK)
                Assert.Fail();
        }

        [TestMethod()]
        public void GetTest1()
        {
            ProductController obj = new ProductController();
            Task<HttpResponseMessage> result = obj.Get(1);
            if (result.Result.StatusCode != HttpStatusCode.OK)
                Assert.Fail();
        }

        [TestMethod()]
        public void PostTest()
        {
            ProductController obj = new ProductController();
            Product prods = new Product();
            prods.AmountPerUnit = 200;
            prods.BaseWeight = 1000;
            prods.CategoryId = 1;
            prods.CreatedBy = "ProductAdmin";
            prods.CreatedDate = DateTime.Now;
            prods.Description = "Product Description";
            //prods.Id;
            prods.IsActive = true;
            prods.IsAvailable = true;
            prods.MeasurementId = 1;
            prods.ModifiedBy = "ProductAdmin";
            prods.ModifiedDate = DateTime.Now;
            prods.Name = "Test Product Name 1";
            Task<HttpResponseMessage> result = obj.Post(prods);
            if (result.Result.StatusCode != HttpStatusCode.OK)
                Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            ProductController obj = new ProductController();
            Product prods = new Product();
            prods.AmountPerUnit = 200;
            prods.BaseWeight = 1000;
            prods.CategoryId = 1;
            prods.CreatedBy = "ProductAdmin";
            prods.CreatedDate = DateTime.Now;
            prods.Description = "Product Description";
            prods.Id = 1;
            prods.IsActive = true;
            prods.IsAvailable = true;
            prods.MeasurementId = 1;
            prods.ModifiedBy = "ProductAdmin";
            prods.ModifiedDate = DateTime.Now;
            prods.Name = "New Test Product Name 1";
            Task<HttpResponseMessage> result = obj.Put(prods);
            if (result.Result.StatusCode != HttpStatusCode.OK)
                Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ProductController obj = new ProductController();
            int id = 1;
            Task<HttpResponseMessage> result = obj.Delete(id);
            if (result.Result.StatusCode != HttpStatusCode.OK)
                Assert.Fail();
        }
    }
}