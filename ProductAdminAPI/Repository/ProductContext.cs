using System.Data.Entity;

namespace ProductAdminAPI.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductDBEntities")
        {
        }
        public DbSet<Product> ProductsDB { get; set; }
        public DbSet<Measurement> MeasurementDB { get; set; }
        public DbSet<Category> CategoryDB { get; set; }
    }
}