using API.Data.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{Id}", Name = "GetItemById")]
        public async Task<ActionResult<Item>> GetItemById(int Id)
        {
            var item = await _repository.GetByIdAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    }
}
