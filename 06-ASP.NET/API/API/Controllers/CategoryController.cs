using API.Data;
using API.Data.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{Id}", Name = "GetByIdAsync")]
        public async Task<ActionResult<Category>> GetByIdAsync(int Id)
        {
            var category = await _repository.GetByIdAsync(Id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CreateCategoryDto dto)
        {
            var category = new Category { Name = dto.Name };

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetByIdAsync), new { Id = category.Id }, category);
        }
    }
}
