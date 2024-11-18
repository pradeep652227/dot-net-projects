using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace MongoAppWebAPI.Models
{
    public class PlaylistModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? CreatedBy { get; set; } = null!;

        public string? PlaylistName { get; set; }= null!;

        public bool? IsPublic { get; set; }

        public decimal? PlaylistRating { get; set; }

        public int? NumberOfMovies { get; set; }

        public DateTime? CreatedOn { get; set; } // Date the playlist was created

        public DateTime? LastUpdatedOn { get; set; } // Date the playlist was last updated

        public string? Description { get; set; } // Description of the playlist

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> MovieIds { get; set; } = null!;

        public string? UserName {  get; set; }
    }

    public class PlaylistModel1
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? CreatedBy { get; set; } = null!;

        public string? PlaylistName { get; set; } = null!;

        public bool? IsPublic { get; set; }

        public decimal? PlaylistRating { get; set; }

        public int? NumberOfMovies { get; set; }

        public DateTime? CreatedOn { get; set; } // Date the playlist was created

        public DateTime? LastUpdatedOn { get; set; } // Date the playlist was last updated

        public string? Description { get; set; } // Description of the playlist


        [BsonRepresentation(BsonType.ObjectId)]
        public string? MovieId { get; set; } = null!;

        public List<MovieModel>? Movie { get; set; }
        public List<MovieModel>? Movies { get; set; }

        public string? UserName { get; set; }
    }


}
