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

        [HttpGet("{id}", Name = "GetById")]
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
            var newVideoGame = await _videoGameRepository.AddVideoGame(videoGame);
            videoGame.Id = newVideoGame;

            return CreatedAtAction(nameof(GetVideoGameById), new { Id = videoGame.Id }, videoGame);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVideoGame(int Id, VideoGame videoGame)
        {
            var checkExisting = await _videoGameRepository.GetVideoGameByIdAsync(Id);
            if (checkExisting == null)
                return NotFound("Video Game NotFound");

            videoGame.Id = Id;
            await _videoGameRepository.UpdateVideoGame(videoGame);
            return NoContent();
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVideoGame(int Id)
        {
            var checkExisting = await _videoGameRepository.GetVideoGameByIdAsync(Id);
            if (checkExisting == null)
                return NotFound("Video Game NotFound");

            await _videoGameRepository.DeleteVideoGame(Id);
            return Ok();
        }
    }
}
