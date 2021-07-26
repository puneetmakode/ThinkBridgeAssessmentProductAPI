using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAdminAPI.Service
{
    public interface IProductService
    {
        Task<List<Models.Product>> GetAllProducts();
        Task<List<Models.Product>> GetProduct(int id);
        Task<bool> SaveProduct(Models.Product product);
        Task<bool> UpdateProduct(Models.Product product);
        Task<bool> DeleteProduct(int Id);
    }
}
