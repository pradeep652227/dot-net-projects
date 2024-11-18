using MongoDB.Driver;
using MongoAppWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoAppWebAPI.Context;
using MongoAppWebAPI.Models.DTO;

namespace MongoAppWebAPI.Context
{
    public class MongoDBContext
    {
        public IMongoCollection<PlaylistModel> _playlistCollection;
        public IMongoCollection<PlaylistModel1> _playlistCollection1;
        public IMongoCollection<UserModel> _userCollection;
        public IMongoCollection<UserModel1> _userCollection1;
        public IMongoCollection<MovieModel> _movieCollection;

        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _playlistCollection = database.GetCollection<PlaylistModel>(mongoDBSettings.Value.PlaylistCollection);
            _userCollection = database.GetCollection<UserModel>(mongoDBSettings.Value.UserCollection);
            _movieCollection= database.GetCollection<MovieModel>(mongoDBSettings.Value.MovieCollection);
            _playlistCollection1 = database.GetCollection<PlaylistModel1>(mongoDBSettings.Value.PlaylistCollection1);
            _userCollection1 = database.GetCollection<UserModel1>(mongoDBSettings.Value.UserCollection1);
        }

    }


}
