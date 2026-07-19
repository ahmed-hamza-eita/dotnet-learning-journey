using DapperVideoGameDbNormalized.Models;

namespace DapperVideoGameDbNormalized.Repositories
{
    public interface IVideoGameRepository
    {
        Task<IEnumerable<VideoGame>> GetAllVideoGamesAsync();
        Task<VideoGame> GetVideoGamesAsync(int Id);
        Task<VideoGame> CreateVideoGameAsync(VideoGame videoGame);
        Task UpdateVideoGameAsync(VideoGame videoGame);
        Task DeleteVideoGameAsync(int Id);
    }
}
