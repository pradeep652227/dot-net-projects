using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoAppWebAPI.Models.DTO
{
    public class UserWithPlaylistWithMoviesDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? PINCode { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public List<PlaylistModel>? Playlists { get; set; }

    }


        public class UserWithPlaylistsDTO1
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? PINCode { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public PlaylistModel? Playlists { get; set; }

    }


    public class UserWithPlaylistsDTO2
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? PINCode { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }

        public PlaylistModel? Playlists { get; set; }
        public List<MovieModel>? Movies { get; set; }

    }

    public class UserWithPlaylistsDTO3
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public List<UserWithPlaylistsDTO4> PlaylistsWithMovies { get; set; }

    }

    public class UserWithPlaylistsDTO4
    {
        public PlaylistModel? Playlist { get; set; }
        public List<MovieModel> Movies { get; set; }
    }

    public class UserWithPlaylistsDTO5
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? PINCode { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }

        public PlaylistModel1? Playlist { get; set; }
        public MovieModel? Movie { get; set; }
    }

    public class UserWithPlaylistsDTO6
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Correctly handle ObjectId as string
        [BsonElement("_id")]
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public List<PlaylistModel1>? Playlists { get; set; }
    }
}
