using ProductCrudApi.DTOs;
using ProductCrudApi.Models;

namespace ProductCrudApi.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<Product>>SearchAsync(string searchKey);
        Task<IEnumerable<Product>> SortByNameAsync(string order);
        Task<PagedResult<Product>> GetPagedAsync(int pageNumber, int pageSize);
    }
}
