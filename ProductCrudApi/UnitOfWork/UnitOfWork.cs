using ProductCrudApi.Data;
using ProductCrudApi.Interfaces;
using ProductCrudApi.Models;
using ProductCrudApi.Repositories;

namespace ProductCrudApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly ApplicationDbContext _context;
       //public IGenericRepository<Product>Products {  get;private set; }

       public IProductRepository Products { get; private set; }

       

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            //Products = new GenericRepository<Product>(_context);
            Products =new ProductRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
         return await _context.SaveChangesAsync();
        }
    }
}
