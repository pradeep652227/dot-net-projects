using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoAppWebAPI.Models
{
    public class MovieModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? MovieId { get; set; }

        public string? MovieName { get; set; }
        public string? MovieDescription { get; set; }
        public string? MovieCreationDate { get; set; }
        public decimal? MovieRating { get; set; }

        public string? EligibleAudience { get; set; }//create a new table of it to get the ids for 18+, 12+

        public bool? IsPublic { get; set; }
        public DateTime? CreatedOn { get; set; } 

        public DateTime? LastUpdatedOn { get; set; }

        public List<string>? Actors { get; set; }//create a new table to get the ids
        public List<string>? Directors { get; set; }//create a new table to get the ids

    } 
}
