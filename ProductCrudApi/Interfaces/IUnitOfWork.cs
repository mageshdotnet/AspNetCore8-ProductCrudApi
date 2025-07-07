using ProductCrudApi.Models;

namespace ProductCrudApi.Interfaces
{
    public interface IUnitOfWork
    {
       // IGenericRepository<Product> Products { get; }
    
        IProductRepository Products { get; }
        Task<int> SaveAsync();

    }
}
