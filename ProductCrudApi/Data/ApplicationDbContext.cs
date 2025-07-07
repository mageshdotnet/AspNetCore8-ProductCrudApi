using Microsoft.EntityFrameworkCore;
using ProductCrudApi.Models;

namespace ProductCrudApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

       



    }
}
