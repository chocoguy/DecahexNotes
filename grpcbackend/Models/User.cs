using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace grpcbackend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Settings { get; set; } = null!;
        public int StorageAllocated { get; set; }
        public string UserExtra { get; set; } = null!;
        public string CustomCSS { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;
        public DateTime AccountCreated { get; set; }
        public string ProfilePic { get; set; } = null!;
        public int CurrentNotes { get; set; }
        public int CurrentFiles { get; set; }
        public int Clout { get; set; }
        public string Ranking { get; set; } = null!;
        public int TotalNotesCreated { get; set; }
        public int TotalFilesCreated { get; set; }


    }
}
