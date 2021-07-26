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
                var cards = await db.ProductsDB.ToListAsync();
                return cards;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Repository.Product>> GetProduct(int id)
        {
            try
            {
                var cards = await db.ProductsDB.Where(c => c.Id == id).ToListAsync();
                return cards;
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
                db.ProductsDB.Add(product);
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
                var res = db.ProductsDB.SingleOrDefault(b => b.Id == product.Id);
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
                    res.CreatedBy = product.CreatedBy;
                    res.CreatedDate = product.CreatedDate;
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
                var res = db.ProductsDB.SingleOrDefault(b => b.Id == Id);
                if (res != null)
                {
                    db.ProductsDB.Remove(res);
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