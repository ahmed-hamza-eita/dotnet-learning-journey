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

        public async Task<int> CreateVideoGameAsync(VideoGame videoGame)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int publisherId = await GetOrCreatePublisherAsync(connection, transaction, videoGame.Publisher.Name);
                        int developerId = await GetOrCreateDeveloperAsync(connection, transaction, videoGame.Developer.Name);
                        var sql = @"Inser Into VideoGames (Title, PublisherId, DeveloperId, ReleaseDate)
                                   Values(@Title, @PublisherId, @DeveloperId, @ReleaseDate);
                                   Select Cast(Scope_Identity() as int;)";

                        var Id = await connection.QuerySingleAsync<int>(sql, new
                        {
                            videoGame.Title,
                            publisherId = publisherId,
                            DeveloperId = developerId,
                            videoGame.ReleaseDate
                        }, transaction);
                        videoGame.Id = Id;
                        if (videoGame.GameDetail != null)
                        {
                            videoGame.GameDetail.VideoGameId = Id;
                            await CraeteGameDetailsAsync(connection, videoGame.GameDetail, transaction);
                        }
                        if (videoGame.Reviews != null)
                        {
                            foreach (var review in videoGame.Reviews)
                            {
                                review.VideoGameId = Id;
                                await CraeteReviewAsync(connection, review, transaction);
                            }
                        }

                        if (videoGame.Platforms != null)
                        {
                            foreach (var platform in videoGame.Platforms)
                            {
                                await CraeteVideoGamePlatformAsync(connection, new VideoGamesPlatform
                                {
                                    VideoGameId = Id,
                                    PlatformId = platform.Id
                                }, transaction);
                            }
                        }
                        return Id;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Task DeleteVideoGameAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VideoGame>> GetAllVideoGamesAsync()
        {
            var sql = GetVideoGameSql(false);
            var videoGame = await QueryVideoGameAsync(sql);
            return videoGame;

        }


        public async Task<VideoGame> GetVideoGamesAsync(int Id)
        {
            var sql = GetVideoGameSql(true);
            var videoGame = await QueryVideoGameAsync(sql, new { Id = Id });
            return videoGame.FirstOrDefault();
        }

        public Task UpdateVideoGameAsync(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        private string GetVideoGameSql(bool withWhereClause)
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
            if (withWhereClause)
                sql += " Where vg.Id = @Id";
            return sql;
        }
        private async Task<IEnumerable<VideoGame>> QueryVideoGameAsync(string Sql, object? Parameters = null)
        {
            using (var connection = GetConnection())
            {

                var videoGameDict = new Dictionary<int, VideoGame>();

                await connection.QueryAsync<VideoGame, Publisher, Developer, GameDetail, Review, Platform, VideoGame>
                   (Sql, (videoGame, publisher, developer, gameDetail, review, platform) =>
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
                   }
                   , Parameters
                   , splitOn: "Id ,Id,VideoGameId,Id,Id");
                return videoGameDict.Values;
            }

        }

        private async Task<int> GetOrCreatePublisherAsync(SqlConnection connection, SqlTransaction transaction, string piblisherName)
        {
            var checkSql = "Select Id From Publishers Where Name = @Name";
            var existingPublisherId = await connection.QueryFirstOrDefaultAsync<int?>
                (checkSql, new { Name = piblisherName }, transaction);

            if (existingPublisherId.HasValue)
                return existingPublisherId.Value;

            var insertSql = @"Insert Into Publishers (Name) Values (@Name);
                              Select Cast(Scope_Identity() as int;)";

            var newPublisherId = await connection.QuerySingleAsync<int>
                (insertSql, new { Name = piblisherName }, transaction);

            return newPublisherId;
        }
        private async Task<int> GetOrCreateDeveloperAsync(SqlConnection connection, SqlTransaction transaction, string developerName)
        {
            var checkSql = "Select Id From Developers Where Name = @Name";
            var existingDevelopersId = await connection.QueryFirstOrDefaultAsync<int?>
                (checkSql, new { Name = developerName }, transaction);

            if (existingDevelopersId.HasValue)
                return existingDevelopersId.Value;

            var insertSql = @"Insert Into Developers (Name) Values (@Name);
                              Select Cast(Scope_Identity) as int;";

            var newDevelopersId = await connection.QuerySingleAsync<int>
                (insertSql, new { Name = developerName }, transaction);

            return newDevelopersId;
        }
        private async Task CraeteGameDetailsAsync(SqlConnection connection, GameDetail gameDetail, SqlTransaction transaction)
        {
            var sql = @"Insert Into GameDetails(VideoGameId,Description,Rating)
                       Values(@VideoGameId, @Description, @Rating);";
            await connection.ExecuteAsync(sql, gameDetail, transaction);
        }

        private async Task CraeteReviewAsync(SqlConnection connection, Review review, SqlTransaction transaction)
        {
            var sql = @"Insert Into Reviews(VideoGameId, ReviewerName, Content, Rating)
                       Values(@VideoGameId, @ReviewerName, @Content, @Rating);";
            await connection.ExecuteAsync(sql, review, transaction);
        }
        private async Task CraeteVideoGamePlatformAsync(SqlConnection connection, VideoGamesPlatform videoGamesPlatform, SqlTransaction transaction)
        {
            var sql = @"Insert Into Platforms(VideoGameId, PlatformId)
                       Values(@VideoGameId, @PlatformId);";
            await connection.ExecuteAsync(sql, videoGamesPlatform, transaction);
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
