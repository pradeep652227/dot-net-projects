using MongoAppWebAPI.Models;
using MongoAppWebAPI.Models.DTO;

namespace MongoAppWebAPI.Services.Abstraction
{
    public interface IPlaylistRepository
    {
        Task<ResultDTO> CreatePlaylistAsync(PlaylistModel playlist);
        Task<ResultDTO> DeletePlaylistAsync(string Id);
        Task<PlaylistModel> GetPlaylistModelAsync(string Id);
        Task<ResultDTO> UpdatePlaylistAsync(string Id, string item1, string item2);
        Task<ResultDTO> UpdatePlaylistModelAsync(string Id, PlaylistModel playlist);
        Task<ResultDTO> CreatePlaylistAsync1(PlaylistModel1 playlist);
        //Task<List<PlaylistWithMoviesDTO>> GetPlaylistWithMoviesAsync(string PlaylistId);
    }
}