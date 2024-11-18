using MongoAppWebAPI.Models;
using MongoDB.Driver;

namespace MongoAppWebAPI.Services.Abstraction
{
    public interface IMovieRepository
    {
        void AddMovieAsync(MovieModel movie);
        Task<MovieModel> GetMovieAsync (string MovieId);

    }
}