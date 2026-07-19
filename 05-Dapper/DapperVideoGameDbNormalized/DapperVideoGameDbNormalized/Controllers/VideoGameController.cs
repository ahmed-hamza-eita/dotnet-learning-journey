using DapperVideoGameDbNormalized.Models;
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

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGamesAsync()
        {
            var getAllVideoGamesAsync = await _videoGameRepository.GetAllVideoGamesAsync();
            return Ok(getAllVideoGamesAsync);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGamesAsync(int Id)
        {
            var getAllVideoGamesAsync = await _videoGameRepository.GetVideoGamesAsync(Id);
            return Ok(getAllVideoGamesAsync);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVideoGame(VideoGame videoGame)
        {
            if (videoGame == null)
                return BadRequest();

            var createdId = await _videoGameRepository.CreateVideoGameAsync(videoGame);
            return CreatedAtAction(nameof(GetVideoGamesAsync), new { Id = createdId }, videoGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVideoGame(int id, VideoGame videoGame)
        {
            if (videoGame == null || videoGame.Id != id)
            {
                return BadRequest();
            }

            var existingVideoGame = await _videoGameRepository.GetVideoGamesAsync(id);
            if (existingVideoGame == null)
            {
                return NotFound();
            }

            await _videoGameRepository.UpdateVideoGameAsync(videoGame);
            return NoContent();
        }
    }
}
