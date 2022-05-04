using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API_Implementation.Controllers
{
    [Route("api/orders")]
    [Controller]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository _repository;

        public OrdersController(IRepository repository)
        {
            _repository = repository;
        }

       

        //HTTP Get
        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrdersAsync()
        {
            try
            {
                List<OrderDTO> orders = await _repository.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            try
            {
                OrderDTO order = await _repository.GetOrderByIdAsync(id);
                if(order == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(order);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        //HTTP Post
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateOrderAsync(order);
                    return CreatedAtAction(nameof(GetOrderById), new { id = order.Id}, order);
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


        //HTTP Put
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                Order updateOrder = await _repository.UpdateOrderAsync(id, order);
                if (updateOrder == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetOrderById), new { id = order.Id}, order);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        //HTTP Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                bool deleteSuccessfull = await _repository.DeleteOrderAsync(id);

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
