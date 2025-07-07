using ProductCrudApi.Models;

namespace ProductCrudApi.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<Product>>SearchAsync(string searchKey);
    }
}
