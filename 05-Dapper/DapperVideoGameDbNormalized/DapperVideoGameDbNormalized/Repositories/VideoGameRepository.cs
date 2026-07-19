using Dapper;
using DapperVideoGameDbNormalized.Models;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DapperVideoGameDbNormalized.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
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

        public async Task<IEnumerable<VideoGame>> GetAllVideoGamesAsync()
        {
            using (var connection = GetConnection())
            {
                var sql = @"
                    SELECT vg.*, p.*, d.*, gd.*, r.*, pf.*
                    FROM VideoGames vg
                    LEFT JOIN Publishers p ON vg.PublisherId = p.Id
                    LEFT JOIN Developers d ON vg.DeveloperId = d.Id
                    LEFT JOIN GameDetails gd ON vg.Id = gd.VideoGameId
                    LEFT JOIN Reviews r ON vg.Id = r.VideoGameId
                    LEFT JOIN VideoGamesPlatforms vgp ON vg.Id = vgp.VideoGameId
                    LEFT JOIN Platforms pf ON pf.Id = vgp.PlatformId";

                var videoGameDict = new Dictionary<int, VideoGame>();

                 await connection.QueryAsync<VideoGame, Publisher, Developer, GameDetail, Review, Platform, VideoGame>
                    (sql, (videoGame, publisher, developer, gameDetail, review, platform) =>
                    {
                        if (!videoGameDict.TryGetValue(videoGame.Id, out var currentGame))
                        {
                            currentGame = videoGame;
                            currentGame.Publisher = publisher;
                            currentGame.Developer = developer;
                            currentGame.GameDetail = gameDetail;
                            currentGame.Reviews = [];
                            currentGame.Platforms = [];
                            videoGameDict.Add(currentGame.Id, currentGame);

                        }
                        if (review is not null && !currentGame.Reviews.Any(r => r.Id == review.Id))
                        {
                            currentGame.Reviews.Add(review);
                        }
                        if (platform is not null && !currentGame.Platforms.Any(r => r.Id == platform.Id))
                        {
                            currentGame.Platforms.Add(platform);
                        }
                        return currentGame;
                    }, splitOn: "Id ,Id,VideoGameId,Id,Id");
                return videoGameDict.Values;
            }

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
