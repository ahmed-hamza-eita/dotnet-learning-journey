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
    }
}
