using MongoAppWebAPI.Models.DTO;
using MongoAppWebAPI.Models;
using MongoDB.Driver;
using MongoAppWebAPI.Services.Abstraction;

namespace MongoAppWebAPI.Services.Implementation
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly IMongoCollection<PlaylistModel> _playlistCollection;
        private readonly IMongoCollection<PlaylistModel1> _playlistCollection1;

        private readonly IMongoCollection<MovieModel> _movieCollection;
        public PlaylistRepository(IMongoCollection<PlaylistModel> playlistCollection,IMongoCollection<MovieModel>movieCollection,
            IMongoCollection<PlaylistModel1> playlistCollection1) 
        {
            _playlistCollection = playlistCollection;
            _movieCollection = movieCollection;
            _playlistCollection1 = playlistCollection1;
        }

        public async Task<ResultDTO> CreatePlaylistAsync(PlaylistModel playlist)
        {
            await _playlistCollection.InsertOneAsync(playlist);
            return new ResultDTO() { isSuccess = true };
        }

        public async Task<ResultDTO> CreatePlaylistAsync1(PlaylistModel1 playlist)
        {
            await _playlistCollection1.InsertOneAsync(playlist);
            return new ResultDTO() { isSuccess = true };
        }
        public async Task<PlaylistModel> GetPlaylistModelAsync(string Id)
        {
            var filter = Builders<PlaylistModel>.Filter.Eq(p => p.Id, Id);

            var playlist = await _playlistCollection.Find(filter).FirstOrDefaultAsync();

            return playlist;
        }

        public async Task<List<PlaylistModel>> GetAllPlaylistsAsync()
        {
            return await _playlistCollection.Find(p=>true).ToListAsync<PlaylistModel>();
        }

        public async Task<ResultDTO> UpdatePlaylistAsync(string Id, string item1, string item2)
        {
            //Query the collection to find the required document
            var filter = Builders<PlaylistModel>.Filter.Eq(p => p.Id, Id);

            ////finding the document
            //var playlist = await _playlistCollection.Find(filter).FirstOrDefaultAsync();

            var playlist = await GetPlaylistModelAsync(Id);

            if (playlist == null)
            {
                return new ResultDTO() { isSuccess = false, Message = "Playlist Not Found" };
            }

            //getting the index of movieIds array
            var itemIndex = playlist.MovieIds.IndexOf(item1);

            if (itemIndex == -1)
            {
                return new ResultDTO() { isSuccess = false, Message = "Movie Not Found in the database" };
            }

            playlist.MovieIds[itemIndex] = item2;

            //ready a document for updation
            var update = Builders<PlaylistModel>.Update.Set(p => p.MovieIds, playlist.MovieIds);

            var res = await _playlistCollection.UpdateOneAsync(filter, update);

            if (res.ModifiedCount > 0)
            {
                return new ResultDTO { isSuccess = true, Message = "Movie updated successfully" };
            }
            else
            {
                return new ResultDTO { isSuccess = false, Message = "Failed to update movie" };
            }
        }

        public async Task<ResultDTO> UpdatePlaylistModelAsync(string Id, PlaylistModel playlist)
        {
            var filter = Builders<PlaylistModel>.Filter.Eq(p => p.Id, Id);

            var res = await _playlistCollection.ReplaceOneAsync(filter, playlist);

            if (res.ModifiedCount > 0)
            {
                return new ResultDTO() { isSuccess = true };
            }
            else
            {
                return new ResultDTO() { isSuccess = false, Message = "Failed To Update Playlist" };
            }
        }

        public async Task<ResultDTO> DeletePlaylistAsync(string Id)
        {
            var filter = Builders<PlaylistModel>.Filter.Eq(p => p.Id, Id);
            var res = await _playlistCollection.DeleteOneAsync(filter);

            if (res.DeletedCount > 0)
            {
                return new ResultDTO() { isSuccess = true };

            }

            return new ResultDTO() { isSuccess = false, Message = "can not delete the model" };

        }

        //
        //public async Task<List<PlaylistWithMovies>> GetPlaylistWithMoviesAsync(string PlaylistId)
        //{
        //    return await _playlistCollection.Aggregate()
        //                                     .Match(p => p.Id == PlaylistId)
        //                                    .Lookup<PlaylistModel, MovieModel, PlaylistWithMovies>(
        //                                     _movieCollection,
        //                                     p => p.MovieIds,
        //                                     m => m.MovieId,
        //                                     pm => pm.Movies
        //                                     ).ToListAsync();
        //}

        
    }
}
