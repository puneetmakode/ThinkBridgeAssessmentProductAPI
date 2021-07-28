using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAdminAPI.Service
{
    public interface IProductService
    {
        Task<List<Models.ProductModel>> GetAllProducts();
        Task<List<Models.ProductModel>> GetProduct(int id);
        Task<bool> SaveProduct(Models.ProductModel product);
        Task<bool> UpdateProduct(Models.ProductModel product);
        Task<bool> DeleteProduct(int Id);
    }
}
