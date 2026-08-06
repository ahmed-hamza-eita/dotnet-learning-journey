using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Tasks.Repositories.Implementation;
using Tasks.Repositories.Interfaces;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _repository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{Id}", Name = ("GetAuthorById"))]
        public async Task<ActionResult<Author>> GetAuthorById(int Id)
        {
            var author = await _repository.GetByIdAsyns(Id);
            if (author == null)
            {
                return NotFound($"Not Found any Autors with Id:{Id}");
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var author = new Author { Name = dto.Name };
            await _repository.AddAsync(author);
            await _repository.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetAuthorById), new { Id = author.Id }, author);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAuthor(int Id)
        {
            var author = await _repository.GetByIdAsyns(Id);
            if (author == null)
            {
                return NotFound($"Not Found any Autors with Id:{Id}");
            }
            _repository.Delete(author);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
