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
    }
}
