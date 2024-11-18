using MongoAppWebAPI.Models;
using MongoAppWebAPI.Models.DTO;
using MongoAppWebAPI.Services.Abstraction;
using MongoDB.Driver;

namespace MongoAppWebAPI.Services.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<MovieModel> _movieCollection;

        public MovieRepository(IMongoCollection<MovieModel> movieCollection)
        {
            _movieCollection = movieCollection;
        }

        public async void AddMovieAsync(MovieModel movie)
        {
            await _movieCollection.InsertOneAsync(movie);
        }

        public async Task<MovieModel> GetMovieAsync(string MovieId)
        {
            var filter = GetMovieFilter(MovieId);
            return await _movieCollection.Find(filter).FirstOrDefaultAsync();
        }


        //Helper Function
        public FilterDefinition<MovieModel> GetMovieFilter(string MovieId)
        {
            return Builders<MovieModel>.Filter.Eq(m => m.MovieId, MovieId);
        }
    }
}
