using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace grpcbackend.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Visibility { get; set; } = null!;
        public string ShareKey { get; set; } = null!;
        public DateTime Added { get; set; }
        public DateTime Edited { get; set; }
        public int Views { get; set; }
    }
}
