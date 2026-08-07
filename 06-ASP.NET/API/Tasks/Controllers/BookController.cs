using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using Task_1.Repositories.Interfaces;
using Tasks.Models.DTOs;
using Tasks.Repositories.Interfaces;

namespace Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IAuthorRepository _authorRepository;
        public BookController(IBookRepository repository, IAuthorRepository authorRepository)
        {
            _repository = repository;
            _authorRepository = authorRepository;
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

            bool alreadyExists = await _repository.ExistsAsync(dto.Title, dto.AuthorId, dto.PublishedDate);
            if (alreadyExists)
            {
                return Conflict($"A book with Title '{dto.Title}', Author '{dto.AuthorId}', and PublishedDate '{dto.PublishedDate}' already exists.");
            }

            var book = new Book { Title = dto.Title, AuthorId = dto.AuthorId, PublishedDate = dto.PublishedDate };
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
            book.AuthorId = dto.AuthorId;
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

        [HttpPost]
        [Route("/api/author/{authorId}/book")]
        public async Task<ActionResult<Book>> CreateBookForAuthor(int authorId, [FromBody] CreateBookForAuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var author = await _authorRepository.GetByIdAsyns(authorId);
            if (author == null)
            {
                return NotFound($"Not Found any Author with Id:{authorId}");
            }

            var alreadyExist = await _repository.ExistsAsync(dto.Title, authorId, dto.PublishedDate);
            if (alreadyExist)
            {
                return Conflict($"A book with Title '{dto.Title}' already exists for this author.");

            }

            var book = new Book { Title = dto.Title, AuthorId = authorId, PublishedDate = dto.PublishedDate };
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetById), new { Id = book.Id }, book);

        }

        [HttpGet]
        [Route("/api/author/{authorId}/book")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(int authorId)
        {
            var author =await _authorRepository.GetByIdAsyns(authorId);
            if (author == null)
            {
                return NotFound($"Not Found any Author with Id:{authorId}");
            }

            var books = await _repository.GetAllWithAuthorAsync();
            var authorBook = books
                .Where(b => b.AuthorId == authorId)
                .Select(book => new
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublishedDate = book.PublishedDate,
                    AuthorId = book.AuthorId,
                    AuthorName = book.Author?.Name ?? string.Empty
                });
            return Ok(authorBook);
        }
    }
}
