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

    }
}
