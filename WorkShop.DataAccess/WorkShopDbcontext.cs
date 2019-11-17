using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkShop.Models;

namespace WorkShop.DataAccess
{
    public class WorkShopDbcontext : DbContext 
    {
        public WorkShopDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CategorieModel> Categories { get; set; }

        public DbSet<StockModel> Stocks { get; set; }

        
    }
}
