using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Repositories.Implementation;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorRepository _repository;
        public AuthorController(AuthorRepository repository)
        {
            _repository = repository;
        }
    }
}
