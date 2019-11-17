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

        public DbSet<Product> Products { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        
    }
}
