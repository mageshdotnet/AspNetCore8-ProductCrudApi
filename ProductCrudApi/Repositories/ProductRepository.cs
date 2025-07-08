using Microsoft.EntityFrameworkCore;
using ProductCrudApi.Data;
using ProductCrudApi.DTOs;
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


        public async Task<IEnumerable<Product>> SortByNameAsync(string order)
        {
            var query = _context.Set<Product>().AsQueryable();

            return order?.ToLower() switch
            {
                "desc" => await Task.FromResult(query.OrderByDescending(p => p.Name).AsEnumerable()),
                _ => await Task.FromResult(query.OrderBy(p => p.Name).AsEnumerable())
            };
        }


        public async Task<PagedResult<Product>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Set<Product>().CountAsync();

            var items = await _context.Set<Product>()
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                TotalCount = totalCount
            };
        }


    }
}
