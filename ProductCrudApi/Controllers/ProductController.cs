using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductCrudApi.DTOs;
using ProductCrudApi.Interfaces;
using ProductCrudApi.Models;

namespace ProductCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid ||
                string.IsNullOrWhiteSpace(productDto.Name) ||
                productDto.Name.Trim().ToLower() == "string" ||
                productDto.Price <= 0)
            {
                return BadRequest("Invalid input: Name must be valid and price > 0.");
            }
           
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

           
            return Ok(products);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound("Product not found");

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;

            await _unitOfWork.Products.UpdateAsync(existingProduct);
            await _unitOfWork.SaveAsync();

            return Ok(new { message = "Product updated successfully", data = existingProduct });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            _unitOfWork.Products.DeleteAsync(product); 
            await _unitOfWork.SaveAsync();

            return Ok($"Product with ID {id} deleted successfully.");
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts(string searchKey)
        {
            if(string.IsNullOrWhiteSpace(searchKey))
            {
                return BadRequest("Searchkey must not be empty.");
            }
            var result = await _unitOfWork.Products.SearchAsync(searchKey);

            if(!result.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }



        [HttpGet("sort")]
        public async Task<IActionResult> SortByName(string order)
        {
            var sortedProducts = await _unitOfWork.Products.SortByNameAsync(order);

            if (!sortedProducts.Any())
                return NotFound("No products found.");

            return Ok(sortedProducts);
        }



        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts(int pageNumber , int pageSize )
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest("Page number and size must be greater than 0.");

            var result = await _unitOfWork.Products.GetPagedAsync(pageNumber, pageSize);

            if (!result.Items.Any())
                return NotFound("No products found for this page.");

            return Ok(result);
        }



    }
}
