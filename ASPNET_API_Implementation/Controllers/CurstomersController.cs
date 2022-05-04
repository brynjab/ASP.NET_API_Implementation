using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API_Implementation.Controllers
{
    [Controller]
    [Route("api/customers")]
    public class CurstomersController : ControllerBase 
    {
        private readonly IRepository _repository;

        public CurstomersController(IRepository repository)
        {
            _repository = repository;
        }


        //GET POST PUT DELETE
        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
        {
            try
            {
                List<CustomerDTO> customers = await _repository.GetAllCustomersAsync();

                return Ok(customers);   

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomersById(int id)
        {
            try
            {
                CustomerDTO customer = await _repository.GetCustomerByIdAsync(id);
                if(customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCustomerAsync(customer);
                    return CreatedAtAction(nameof(GetCustomersById), new { id = customer.Id }, customer);
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
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer updatedCustomer = await _repository.UpdateCustomerAsync(id, customer);
                if(updatedCustomer == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCustomersById), new { id = updatedCustomer.Id}, updatedCustomer);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                bool deleteSuccessfull = await _repository.DeleteCustomerAsync(id);
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
