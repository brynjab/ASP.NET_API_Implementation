using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API_Implementation.Controllers
{
    [Controller]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            try
            {
                List<ProductDTO> products = await _repository.GetAllProductsAsync();

                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                ProductDTO product = await _repository.GetProductByIdAsync(id);
                if(product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateProductAsync(product);
                    return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product) {
            try
            {
                Product updatedProduct = await _repository.UpdateProductAsync(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetProductById), new { id = updatedProduct.Id }, updatedProduct);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                bool deleteSuccessfull = await _repository.DeleteProductAsync(id);
                if (!deleteSuccessfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        } 
    }
}
