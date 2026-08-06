using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using Task_1.Repositories.Interfaces;

namespace Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{Id}", Name = "GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            var book = await _repository.GetByIdAsyns(Id);
            if (book == null)
                return NotFound($"Not Found any books with Id:{Id}");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] CreateBookDto dto)
        {
            //Ensure Data Annotations ([Required], [MaxLength])
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool alreadyExists = await _repository.ExistsAsync(dto.Title, dto.Author, dto.PublishedDate);
            if (alreadyExists)
            {
                return Conflict($"A book with Title '{dto.Title}', Author '{dto.Author}', and PublishedDate '{dto.PublishedDate}' already exists.");
            }

            var book = new Book { Title = dto.Title, Author = dto.Author, PublishedDate = dto.PublishedDate };
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetById), new { Id = book.Id }, book);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateAsync(int Id, CreateBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = await _repository.GetByIdAsyns(Id);
            if (book == null)
            {
                return NotFound($"Not Found any books with Id:{Id}");
            }


            book.Title = dto.Title;
            book.Author = dto.Author;
            book.PublishedDate = dto.PublishedDate;

            _repository.Update(book);
            await _repository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var book = await _repository.GetByIdAsyns(Id);
            if (book == null)
            {
                return NotFound($"Not Found any books with Id:{Id}");
            }
            _repository.Delete(book);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
