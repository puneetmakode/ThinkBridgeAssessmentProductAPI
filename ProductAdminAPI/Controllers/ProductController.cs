using ProductAdminAPI.Repository;
using ProductAdminAPI.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductAdminAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _iProductRepository = null;
        private readonly IProductService _iProductService = null;

        public ProductController()
        {
            IProductRepository _iRepo = null;
            _iProductRepository = new ProductRepository(_iRepo);
            _iProductService = new ProductService(_iProductRepository);
        }

        // GET api/product
        public async Task<HttpResponseMessage> Get()
        {
            List<Models.ProductModel> results = new List<Models.ProductModel>();
            try
            {
                results = await _iProductService.GetAllProducts();
            }
            catch (Exception ex)
            {
                HttpError myCustomError = new HttpError(ex.Message) { };
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
            }
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // GET api/product/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            List<Models.ProductModel> results = new List<Models.ProductModel>();
            try
            {
                results = await _iProductService.GetProduct(id);
            }
            catch (Exception ex)
            {
                HttpError myCustomError = new HttpError(ex.Message) { };
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
            }
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // POST api/product
        public async Task<HttpResponseMessage> Post([FromBody] Models.ProductModel product)
        {
            if (ModelState.IsValid)
            {
                bool flg;
                try
                {
                    flg = await _iProductService.SaveProduct(product);
                }
                catch (Exception ex)
                {
                    HttpError myCustomError = new HttpError(ex.Message) { };
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
                }
                return Request.CreateResponse(HttpStatusCode.OK, flg);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/product/
        public async Task<HttpResponseMessage> Put([FromBody] Models.ProductModel product)
        {
            if (ModelState.IsValid)
            {
                bool flg;
                try
                {
                    flg = await _iProductService.UpdateProduct(product);
                }
                catch (Exception ex)
                {
                    HttpError myCustomError = new HttpError(ex.Message) { };
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
                }
                return Request.CreateResponse(HttpStatusCode.OK, flg);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/product/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            bool flg;
            try
            {
                flg = await _iProductService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                HttpError myCustomError = new HttpError(ex.Message) { };
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);
            }
            return Request.CreateResponse(HttpStatusCode.OK, flg);
        }
    }
}
