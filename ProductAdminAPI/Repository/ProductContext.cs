using System.Data.Entity;

namespace ProductAdminAPI.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductDBEntities")
        {
        }
        public DbSet<Repository.Product> Product { get; set; }
        public DbSet<Repository.Measurement> Measurement { get; set; }
        public DbSet<Repository.Category> Category { get; set; }
    }
}