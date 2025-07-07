using Microsoft.EntityFrameworkCore;
using ProductCrudApi.Data;
using ProductCrudApi.Interfaces;
using ProductCrudApi.Models;

namespace ProductCrudApi.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> SearchAsync(string searchKey)
        {
         return await _context.Products
                .Where(p => p.Name.Contains(searchKey))
                .ToListAsync();
        }
    }
}
