using MongoAppWebAPI.Models;
using MongoAppWebAPI.Models.DTO;
using MongoAppWebAPI.Services.Abstraction;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography.Xml;

namespace MongoAppWebAPI.Services.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _userCollection;
        private readonly IMongoCollection<PlaylistModel> _playlistCollection;
        private readonly IMongoCollection<MovieModel> _movieCollection;

        private readonly IMongoCollection<UserModel1> _userCollection1;
        private readonly IMongoCollection<PlaylistModel1> _playlistCollection1;

        public UserRepository(IMongoCollection<UserModel> userCollection, IMongoCollection<PlaylistModel> playlistCollection
            , IMongoCollection<MovieModel> movieCollection,
           IMongoCollection<UserModel1> userCollection1,
           IMongoCollection<PlaylistModel1> playlistCollection1)
        {
            _userCollection = userCollection;
            _playlistCollection = playlistCollection;
            _movieCollection = movieCollection;
            _userCollection1 = userCollection1;
            _playlistCollection1 = playlistCollection1;
        }

        //AddUser
        public async void AddUserAsync(UserModel user)
        {
            await _userCollection.InsertOneAsync(user);

        }

        //GetUser
        public async Task<UserModel> GetUserAsync(string UserId)
        {
            var filter = GetUserFilter(UserId);

            var user = await _userCollection.Find(filter).FirstOrDefaultAsync();

            return user;
        }

        //GetAllUsers
        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _userCollection.Find(u => true).ToListAsync<UserModel>();

            return users;
        }

        //UpdateUser
        public async Task<ResultDTO> UpdateUserModelAsync(string userId, Dictionary<string, object> fieldsToUpdate)
        {
            // Filter to find the user by their ID
            var filter = Builders<UserModel>.Filter.Eq(u => u.UserId, userId);

            // Initialize an empty update definition
            var updateDefinition = new List<UpdateDefinition<UserModel>>();

            // Iterate over the fields in the incoming object and add them to the update definition
            foreach (var field in fieldsToUpdate)
            {
                updateDefinition.Add(Builders<UserModel>.Update.Set(field.Key, field.Value));
            }

            // Combine all update definitions using Builders<UserModel>.Update.Combine
            var combinedUpdate = Builders<UserModel>.Update.Combine(updateDefinition);

            // Execute the update
            var res = await _userCollection.UpdateOneAsync(filter, combinedUpdate);

            if (res.ModifiedCount > 0)
            {
                return new ResultDTO() { isSuccess = true };
            }
            return new ResultDTO() { isSuccess = false, Message = $"User with UserId ${userId} is not updated" };
        }

        //Delete A User
        public async Task<ResultDTO> DeleteUserAsync(string UserId)
        {
            var filter = GetUserFilter(UserId);
            var res = await _userCollection.DeleteOneAsync(filter);

            if (res.DeletedCount > 0)
            {
                return new ResultDTO { isSuccess = true };
            }
            return new ResultDTO() { isSuccess = false, Message = $"User is not Deleted with UserId-{UserId}" };
        }

        public async Task<List<PlaylistModel>> GetPlaylistsForUser(string UserId)
        {
            var filter = GetUserFilter(UserId);
            var user = await _userCollection.Find(filter).FirstOrDefaultAsync();
            if (user == null)
                return null;

            var PlaylistIds = user.Playlists.ToList();
            if (PlaylistIds == null || PlaylistIds.Count == 0)
                return null;

            var Playlists = new List<PlaylistModel>();
            foreach (var playlistId in PlaylistIds)
            {
                var Filter1 = Builders<PlaylistModel>.Filter.Eq(p => p.Id, playlistId);
                var Playlist = await _playlistCollection.Find(Filter1).FirstOrDefaultAsync();
                Playlists.Add(Playlist);
            }

            return Playlists;

        }

        public async Task<List<UserWithPlaylistsDTO>> GetUserWithPlaylistsDataAsync(string UserId)
        {
            return await _userCollection.Aggregate()//started the aggregate pipeline
                                         .Match(u => u.UserId == UserId)//filtered the documents
                                         .Lookup<UserModel, PlaylistModel, UserWithPlaylistsDTO>(//start the left join
                                            _playlistCollection,//other collection to join to
                                            u => u.Playlists,//key to join
                                            p => p.Id,//other collection's foreign key
                                            up => up.Playlists//joined data to join to, of PlaylistModel
                                            )
                                         .Project(up => new UserWithPlaylistsDTO()
                                         {
                                             UserId = up.UserId,
                                             UserName = up.UserName,
                                             UserEmail = up.UserEmail,
                                             UserPassword = up.UserPassword,
                                             Playlists = up.Playlists.Select(p => new PlaylistModel()
                                             {
                                                 UserName = p.UserName,
                                                 MovieIds = p.MovieIds
                                             }).ToList()
                                         })
                     .ToListAsync();
        }


        public async Task<List<UserWithPlaylistsDTO6>> GetUserWithPlaylistWithMovieAsync2(string UserId)
        {
            // Ensure the userId is valid ObjectId before running the query
            ObjectId validUserId;
            if (!ObjectId.TryParse(UserId, out validUserId))
            {
                throw new ArgumentException("Invalid UserId format.");
            }
            // Define the pipeline stages using PipelineDefinition
            PipelineDefinition < UserModel1, UserWithPlaylistsDTO6 > pipeline = new[]
            {
            new BsonDocument("$match",
                new BsonDocument("_id", new ObjectId(UserId))),

            new BsonDocument("$lookup",
                new BsonDocument
                {
                    { "from", "Playlist1" }, // Playlist collection
                    { "localField", "PlaylistId" }, // Playlist IDs in User
                    { "foreignField", "_id" }, // Playlist IDs in Playlist collection
                    { "as", "playlists" } // Output field
                }),

            new BsonDocument("$unwind",
                new BsonDocument
                {
                    { "path", "$playlists" },
                    { "preserveNullAndEmptyArrays", true }
                }),

            new BsonDocument("$lookup",
                new BsonDocument
                {
                    { "from", "Movie" }, // Movie collection
                    { "localField", "playlists.MovieId" }, // Movie IDs in Playlist
                    { "foreignField", "_id" }, // Movie IDs in Movie collection
                    { "as", "playlists.Movies" } // Output field for movies
                }),

            new BsonDocument("$group",
                new BsonDocument
                {
                    { "_id", "$_id" },
                    { "UserName", new BsonDocument("$first", "$UserName") },
                    { "UserEmail", new BsonDocument("$first", "$UserEmail") },
                    { "Playlists", new BsonDocument("$push", "$playlists") }
                })
        };

            // Run the aggregation pipeline
            var aggregateResult = _userCollection1.Aggregate(pipeline);
            var res = await aggregateResult.ToListAsync();
            return res; // Return the result as BsonDocument
        }

        public async Task<List<UserWithPlaylistsDTO3>> GetUserWithPlaylistWithMovieAsync(string UserId)
        {
            return await _userCollection.Aggregate()
                                        .Match(u => u.UserId == UserId)
                                        .Lookup<UserModel, PlaylistModel, UserWithPlaylistWithMoviesDTO>(
                                         _playlistCollection,
                                         u => u.Playlists,
                                         p => p.Id,
                                         up => up.Playlists
                                        )
                                        .Unwind<UserWithPlaylistWithMoviesDTO, UserWithPlaylistsDTO1>(u => u.Playlists)
                                        .Lookup<UserWithPlaylistsDTO1, MovieModel, UserWithPlaylistsDTO2>(
                                                        _movieCollection,
                                                        u => u.Playlists.MovieIds,
                                                        m => m.MovieId,
                                                        upd => upd.Movies
                                        )
                                        .Group(u => new { u.UserId, u.UserName, u.UserEmail, u.UserPassword },
                                        up => new UserWithPlaylistsDTO3()
                                        {
                                            UserId = up.Key.UserId,
                                            UserName = up.Key.UserName,
                                            PlaylistsWithMovies = up.Select(upd => new UserWithPlaylistsDTO4()
                                            {
                                                Playlist = upd.Playlists,
                                                Movies = upd.Movies
                                            }).ToList()
                                        })
                                        .ToListAsync();


        }

        public async void AddUser1Async(UserModel1 user)
        {
            await _userCollection1.InsertOneAsync(user);

        }
        public async Task<UserModel1> GetUserModel1Async(string UserId)
        {
            var filter = Builders<UserModel1>.Filter.Eq(u => u.UserId, UserId);
            return await _userCollection1.Find(filter).FirstOrDefaultAsync();
        }
        //public async Task<UserModel1> GetUserWithPlaylistWithMovieAsync1(string UserId)
        //{
        //    return await _userCollection1.Aggregate()
        //                                 .Match(u => u.UserId == UserId)
        //                                 .Lookup<UserModel1, PlaylistModel1, UserModel1>(
        //                                    _playlistCollection1,
        //                                    u => u.PlaylistId,
        //                                    p => p.Id,
        //                                    u => u.Playlist
        //                                    )
        //                                 .Unwind<UserModel1, UserModel1>(u => u.Playlist)
        //                                 .FirstOrDefaultAsync();

        //}


        public async Task<UserWithPlaylistsDTO5> GetUserWithPlaylistWithMovieAsync1(string UserId)
        {
            return await _userCollection1.Aggregate()
                                          .Match(u => u.UserId == UserId)
                                          .Lookup<UserModel1, PlaylistModel1, UserWithPlaylistDTO1>(
                                             _playlistCollection1,
                                             u => u.PlaylistId,
                                             p => p.Id,
                                             up => up.Playlist
                                               )
                                          .Unwind<UserWithPlaylistDTO1, UserWithPlaylistDTO1>(u => u.Playlist)
                                          .Lookup<UserWithPlaylistDTO1, MovieModel, UserWithPlaylistsDTO5>
                                          (
                                                 _movieCollection,
                                                 up => up.Playlist.MovieId,
                                                 m => m.MovieId,
                                                 upd => upd.Movie
                 )
                                          .Project(upd => new UserWithPlaylistsDTO5()
                                          {
                                              UserId = upd.UserId,
                                              Playlist = new PlaylistModel1() { PlaylistName = upd.Playlist.PlaylistName },
                                              Movie = upd.Movie
                                          })
                                          .Unwind<UserWithPlaylistsDTO5, UserWithPlaylistsDTO5>(u => u.Movie)
                                          .FirstOrDefaultAsync();

        }

        //Helper Function
        public FilterDefinition<UserModel> GetUserFilter(string UserId)
        {
            return Builders<UserModel>.Filter.Eq(u => u.UserId, UserId);
        }
    }
    /*
        public async Task<List<UserWithPlaylistsDTO3>> GetUserWithPlaylistWithMovieAsync(string UserId)
        {
            return await _userCollection.Aggregate()
                                        .Match(u => u.UserId == UserId)
                                        .Lookup<UserModel, PlaylistModel, UserWithPlaylistWithMoviesDTO>(
                                         _playlistCollection,
                                         u => u.Playlists,
                                         p => p.Id,
                                         up => up.Playlists
                                        )
                                        .Unwind<UserWithPlaylistWithMoviesDTO, UserWithPlaylistsDTO1>(u => u.Playlists)
                                        .Lookup<UserWithPlaylistsDTO1, MovieModel, UserWithPlaylistsDTO2>(
                                                        _movieCollection,
                                                        u => u.Playlists.MovieIds,
                                                        m => m.MovieId,
                                                        upd => upd.Movies
                                        )
                                        .Group(u=> new { u.UserId,u.UserName,u.UserEmail,u.UserPassword},
                                        up=>new UserWithPlaylistsDTO3(){
                                               UserId=up.Key.UserId,
                                               UserName=up.Key.UserName,
                                               PlaylistsWithMovies=up.Select(upd=>new UserWithPlaylistsDTO4()
                                               {
                                                   Playlist=upd.Playlists,
                                                   Movies=upd.Movies
                                               }).ToList()                                        
                                        })
                                        .ToListAsync();


        }
     
     */
}

