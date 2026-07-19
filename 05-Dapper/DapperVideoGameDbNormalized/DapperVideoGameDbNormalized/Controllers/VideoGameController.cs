using DapperVideoGameDbNormalized.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperVideoGameDbNormalized.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGameController(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }
    }
}
