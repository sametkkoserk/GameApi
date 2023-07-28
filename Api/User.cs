using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string? userName { get; set; }

        public string? email { get; set; }

        public string? name { get; set; }

        public string? surName { get; set; }

        public string? fullName { get; set; }

        public string? gender { get; set; }

        public DateTime registerDate { get; set; }

        public DateTime lastLogin { get; set; }

    }
}