using MongoAppWebAPI.Context;
using MongoAppWebAPI.Models;
using MongoAppWebAPI.Services.Abstraction;
using MongoDB.Driver;

namespace MongoAppWebAPI.Services.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        //Instances
        private readonly MongoDBContext _dbContext;
        private readonly IMongoCollection<PlaylistModel> _playlistCollection;
        private readonly IMongoCollection<UserModel> _userCollection;
        private readonly IMongoCollection<MovieModel> _movieCollection;

        private readonly IMongoCollection<PlaylistModel1> _playlistCollection1;
        private readonly IMongoCollection<UserModel1> _userCollection1;
        //Interfaces
        private IPlaylistRepository _iPlaylistRepository;
        private IUserRepository _iUserRepository;
        private IMovieRepository _iMovieRepository;

        //Constructor
        public UnitOfWork(MongoDBContext dbContext)
        {
            _playlistCollection = dbContext._playlistCollection;
            _userCollection = dbContext._userCollection;
            _movieCollection = dbContext._movieCollection;
            _playlistCollection1 = dbContext._playlistCollection1;
            _userCollection1 = dbContext._userCollection1;
            _dbContext = dbContext;
        }
        public IPlaylistRepository iPlaylistRepository
        {
            get { return _iPlaylistRepository ?? (_iPlaylistRepository = new PlaylistRepository(_playlistCollection,_movieCollection,_playlistCollection1)); }

            set { }
        }

        public IUserRepository iUserRepository
        {
            get
            {
                return _iUserRepository ?? (_iUserRepository = new UserRepository(_userCollection, _playlistCollection, _movieCollection,_userCollection1,_playlistCollection1));
            }
            set { }
        }
        public IMovieRepository iMovieRepository
        {
            get
            {
                return _iMovieRepository ?? (_iMovieRepository = new MovieRepository(_movieCollection));
            }
            set { }
        }
    }
}
