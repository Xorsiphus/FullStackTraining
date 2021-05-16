using System.Data.Entity;
using FirstApp.Models;

namespace FirstApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDBContext")
        {
        }

        public DbSet<Item> Item { get; set; }
        
        public DbSet<Category> Categoty { get; set; }
    }
}