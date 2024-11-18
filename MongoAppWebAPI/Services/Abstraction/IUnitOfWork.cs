namespace MongoAppWebAPI.Services.Abstraction
{
    public interface IUnitOfWork
    {
        IPlaylistRepository iPlaylistRepository { get; set; }
        IUserRepository iUserRepository { get; set; }
        IMovieRepository iMovieRepository { get; set; }

    }
}