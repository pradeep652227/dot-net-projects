using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoAppWebAPI.Models.DTO
{
    public class UserWithPlaylistsDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]//llow passing the parameter as type string instead of an ObjectId structure. Mongo handles the conversion from string to ObjectId.

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public List<PlaylistModel>? Playlists { get; set; }
    }

    public class UserWithPlaylistDTO1
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]//llow passing the parameter as type string instead of an ObjectId structure. Mongo handles the conversion from string to ObjectId.

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
    }
}
