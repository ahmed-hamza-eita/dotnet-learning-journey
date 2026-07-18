using DapperCourse.Models;

namespace DapperCourse.Repositories
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllVideoGamesAsync();
        Task<VideoGame> GetVideoGameByIdAsync(int Id);

        Task UpdateVideoGame(VideoGame videoGame);
        Task AddVideoGame(VideoGame videoGame);
        Task DeleteVideoGame(int id);
    }
}
