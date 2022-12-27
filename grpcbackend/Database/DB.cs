using MongoDB.Driver;
using grpcbackend.Models;

namespace grpcbackend.Database
{
    public class DB
    {
        public readonly IMongoCollection<Models.File> filesCollection;
        public readonly IMongoCollection<User> usersCollection;
        public readonly IMongoCollection<Note> notesCollection;

        public MongoClient _mongoClient { get; set; }

        private readonly IConfiguration _configuration;

        public DB(IConfiguration configuration)
        {
            _configuration = configuration;

            _mongoClient = new MongoClient("");

            var notesDB = _mongoClient.GetDatabase("decahexnotes");

            filesCollection = notesDB.GetCollection<Models.File>("files");
            usersCollection = notesDB.GetCollection<User>("users");
            notesCollection = notesDB.GetCollection<Note>("notes");
            //commit

        }


    }
}
