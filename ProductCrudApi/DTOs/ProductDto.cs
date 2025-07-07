using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductCrudApi.DTOs
{
    public class ProductDto
    {

      
        public string Name { get; set; } = string.Empty;
      
        public decimal Price { get; set; }

    }
}
