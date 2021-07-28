using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdminAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext db = new ProductContext();
        public IProductRepository repos = null;
        public ProductRepository(IProductRepository Repos)
        {
            repos = Repos;
        }

        public async Task<List<Repository.Product>> GetAllProducts()
        {
            try
            {
                var prods = await db.Product.ToListAsync<Repository.Product>();
                return prods;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Repository.Product>> GetProduct(int id)
        {
            try
            {
                var prod = await db.Product.Where(c => c.Id == id).ToListAsync();
                return prod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> SaveProduct(Repository.Product product)
        {
            bool result = false;
            try
            {
                var prods = await db.Product.ToListAsync();
                foreach (var itm in prods)
                {
                    if (itm.Name.ToLower() == product.Name.ToLower() && itm.Description.ToLower() == product.Description.ToLower() &&
                        itm.CategoryId == product.CategoryId)
                    {
                        throw new Exception("Product already Exists");
                    }
                }
                db.Product.Add(product);
                int res = await db.SaveChangesAsync();
                if (res != 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
        public async Task<bool> UpdateProduct(Repository.Product product)
        {
            bool result = false;
            try
            {
                var res = db.Product.SingleOrDefault(b => b.Id == product.Id);
                if (res != null)
                {
                    res.IsActive = product.IsActive;
                    res.IsAvailable = product.IsAvailable;
                    res.MeasurementId = product.MeasurementId;
                    res.ModifiedBy = product.ModifiedBy;
                    res.ModifiedDate = product.ModifiedDate;
                    res.Name = product.Name;
                    res.AmountPerUnit = product.AmountPerUnit;
                    res.BaseWeight = product.BaseWeight;
                    res.CategoryId = product.CategoryId;
                    res.Description = product.Description;
                    int isMod = await db.SaveChangesAsync();
                    if (isMod != 0)
                        result = true;
                    else
                        result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
        public async Task<bool> DeleteProduct(int Id)
        {
            bool result = false;
            try
            {
                var res = db.Product.SingleOrDefault(b => b.Id == Id);
                if (res != null)
                {
                    db.Product.Remove(res);
                    int isMod = await db.SaveChangesAsync();
                    if (isMod != 0)
                        result = true;
                    else
                        result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
    }
}