using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductCrudApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Precision(18,4)]
        public decimal Price { get; set; }
    }
}
