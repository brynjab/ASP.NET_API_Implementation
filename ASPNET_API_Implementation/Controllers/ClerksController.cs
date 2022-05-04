using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API_Implementation.Controllers
{
    [Controller]
    [Route("api/clerks")]
    public class ClerksController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClerksController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ClerkDTO>>> GetAllClerks()
        {
            try
            {
                List<ClerkDTO> clerks = await _repository.GetAllClerksAsync();
                return Ok(clerks);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Clerk>>> GetClerkById(int id)
        {
            try
            {
                ClerkDTO c = await _repository.GetClerkByIdAsync(id);
                if(c == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(c);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateClerk([FromBody] Clerk clerk)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateClerkAsync(clerk);
                    return CreatedAtAction(nameof(GetClerkById), new {id = clerk.Id}, clerk);
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
        public async Task<IActionResult> UpdateClerk(int id, [FromBody] Clerk clerk)
        {
            try
            {
                Clerk updatedClerk = await _repository.UpdateClerkAsync(id, clerk);
                if(updatedClerk == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetClerkById), new { id = updatedClerk.Id}, updatedClerk);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Clerk>> DeleteClerk(int id)
        {
            try
            {
                bool deleteSuccessfull = await _repository.DeleteClerkAsync(id);
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
