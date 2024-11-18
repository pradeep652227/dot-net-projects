using MongoAppWebAPI.Context;

namespace MongoAppWebAPI.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PlaylistCollection { get; set; } = null!;
        public string PlaylistCollection1 { get; set; } = null!;

        public string UserCollection { get; set; } = null!;

        public string UserCollection1 { get; set; } = null!;

        public string MovieCollection { get; set; } = null!;


    }
}
