using DapperCourse.Models;

namespace DapperCourse.Repositories
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllVideoGamesAsync();
    }
}
