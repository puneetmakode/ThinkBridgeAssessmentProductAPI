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

        // GET api/values
        public async Task<HttpResponseMessage> Get()
        {
            List<Models.Product> results = new List<Models.Product>();
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

        // GET api/values/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            List<Models.Product> results = new List<Models.Product>();
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

        // POST api/values
        public async Task<HttpResponseMessage> Post([FromBody] Models.Product product)
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

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put([FromBody] Models.Product product)
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

        // DELETE api/values/5
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
