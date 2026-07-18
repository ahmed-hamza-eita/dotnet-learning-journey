using DapperCourse.Models;
using DapperCourse.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperCourse.Controllers
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
            var videoGame = await _videoGameRepository.GetAllVideoGamesAsync();
            return Ok(videoGame);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int Id)
        {
            var getVideoGameById = await _videoGameRepository.GetVideoGameByIdAsync(Id);

            if (getVideoGameById == null)
                return NotFound("This video game not exists in database");

            return Ok(getVideoGameById);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewVideoGame(VideoGame videoGame)
        {
            await _videoGameRepository.AddVideoGame(videoGame);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVideoGame(VideoGame videoGame)
        {
            await _videoGameRepository.UpdateVideoGame(videoGame);
            return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVideoGame(int Id)
        {
            var checkExisting = _videoGameRepository.GetVideoGameByIdAsync(Id);
            if (checkExisting == null)
                return NotFound("Video Game NotFound");

            await _videoGameRepository.DeleteVideoGame(Id);
            return Ok();
        }
    }
}
