using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAdminAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Repository.Product>> GetAllProducts();
        Task<List<Repository.Product>> GetProduct(int id);
        Task<bool> SaveProduct(Repository.Product product);
        Task<bool> UpdateProduct(Repository.Product product);
        Task<bool> DeleteProduct(int Id);
    }
}
