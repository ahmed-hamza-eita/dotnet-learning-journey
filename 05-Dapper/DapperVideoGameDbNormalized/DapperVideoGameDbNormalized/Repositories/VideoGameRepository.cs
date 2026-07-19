using DapperVideoGameDbNormalized.Models;
using Microsoft.Data.SqlClient;

namespace DapperVideoGameDbNormalized.Repositories
{
    public class VideoGameRepository :IVideoGameRepository
    {
        private readonly IConfiguration _configuration;
        public VideoGameRepository(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public Task<VideoGame> CreateVideoGameAsync(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVideoGameAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoGame>> GetAllVideoGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VideoGame> GetVideoGamesAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVideoGameAsync(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
