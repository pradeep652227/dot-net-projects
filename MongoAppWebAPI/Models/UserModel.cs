using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAppWebAPI.Models
{
    public class UserModel
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

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? Playlists { get; set; } = null!;
    }

    public class UserModel1
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

        [BsonRepresentation(BsonType.ObjectId)]
        public string? PlaylistId { get; set; }

        public PlaylistModel1? Playlist { get; set; }
    }
}
