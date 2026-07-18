using Dapper;
using DapperCourse.Models;
using Microsoft.Data.SqlClient;

namespace DapperCourse.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly IConfiguration _configuration;
        public VideoGameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<VideoGame>> GetAllVideoGamesAsync()
        {
            using var connection = GetConnection();
            var videoGames = await connection.QueryAsync<VideoGame>("Select * From VideoGames");
            return videoGames.ToList();
        }
        public async Task<VideoGame> GetVideoGameByIdAsync(int Id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var getVideoGameById = await connection
                    .QueryFirstOrDefaultAsync<VideoGame>("Select * From VideoGames where Id = @Id", new { Id = Id });
                return getVideoGameById;
            }
        }
        public Task AddVideoGame(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVideoGame(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVideoGame(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
