using MongoAppWebAPI.Models;
using MongoAppWebAPI.Models.DTO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoAppWebAPI.Services.Abstraction
{
    public interface IUserRepository
    {
        void AddUserAsync(UserModel user);
        Task<ResultDTO> DeleteUserAsync(string UserId);
        Task<UserModel> GetUserAsync(string UserId);
        Task<List<UserModel>> GetUsersAsync();
        Task<ResultDTO> UpdateUserModelAsync(string UserId, Dictionary<string,object> FieldsToUpdate);
        Task<List<PlaylistModel>> GetPlaylistsForUser(string UserId);
        Task<List<UserWithPlaylistsDTO>> GetUserWithPlaylistsDataAsync(string UserId);
        Task<List<UserWithPlaylistsDTO3>> GetUserWithPlaylistWithMovieAsync(string UserId);
        Task<UserModel1> GetUserModel1Async(string UserId);
        //Task<UserModel1> GetUserWithPlaylistWithMovieAsync1(string UserId);

        Task<UserWithPlaylistsDTO5> GetUserWithPlaylistWithMovieAsync1(string UserId);
        Task <List<UserWithPlaylistsDTO6>> GetUserWithPlaylistWithMovieAsync2(string UserId);

        void AddUser1Async(UserModel1 user); 
    }
}