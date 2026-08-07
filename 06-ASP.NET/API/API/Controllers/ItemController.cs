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

        [HttpPost]
        public async Task<ActionResult<Item>> AddItem([FromForm] CreateItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using var stream = new MemoryStream();
            await dto.Image.CopyToAsync(stream);

            /*
            bool alreadyExist = await _repository.ExistsAsync(dto.Name, dto.Price, dto.Note, dto.Image, dto.categoryId);
            if (alreadyExist)
            {
                return Conflict($"This Item already exists.");

            }
            */

            var item = new Item { Name = dto.Name, Price = dto.Price, Note = dto.Note, Image = stream.ToArray(), categoryId = dto.categoryId };

            await _repository.AddAsync(item);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetItemById), new { Id = item.Id }, item);
        }

        //Extension route
        [HttpGet("ItemsWithCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsWithCategory(int categoryId)
        {
            var item = await _repository.GetItemsWithCategory(categoryId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    }
}
