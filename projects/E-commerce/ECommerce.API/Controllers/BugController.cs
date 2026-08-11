using AutoMapper;
using ECommerce.API.Helper;
using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{

    [Route("api/[controller]")]
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("not-found")]
        public async Task<ActionResult> GetNotFound()
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(600);
            if (category is null)
                return NotFound(new ResponseAPI(404, "No category found with Id: 600"));

            return Ok(new ResponseAPI(200) { Data = category });
        }

        [HttpGet("server-error")]
        public Task<ActionResult> GetServerError()
        {
            throw new Exception("Simulated server error for testing purposes");
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            if (id <= 0)
                return BadRequest(new ResponseAPI(400, "Id must be greater than zero"));

            return Ok(new ResponseAPI(200, $"Valid Id received: {id}"));
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized(new ResponseAPI(401, "You must be logged in to access this resource"));
        }

        [HttpGet("forbidden")]
        public ActionResult GetForbidden()
        {
            return StatusCode(403, new ResponseAPI(403, "You don't have permission to access this resource"));
        }

        [HttpGet("conflict")]
        public ActionResult GetConflict()
        {
            return Conflict(new ResponseAPI(409, "A category with this name already exists"));
        }

        [HttpGet("timeout")]
        public async Task<ActionResult> GetTimeout()
        {
            await Task.Delay(TimeSpan.FromSeconds(30));
            return Ok(new ResponseAPI(200, "Finished after delay"));
        }
    }
}
