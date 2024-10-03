using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Builder = new ConfigurationBuilder().AddJsonFile("appsettings.json" , true , true).Build();
            var connection = Builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);

        }

    }
}
