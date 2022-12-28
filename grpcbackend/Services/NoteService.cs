using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using grpcbackend.Database;
using grpcbackend.Models;
using MongoDB.Driver;


namespace grpcbackend.Services
{
    public class NoteService : Notep.NotepBase
    {
        private readonly DB _db;

        public NoteService(DB db)
        {
            _db = db;
        }

        public override async Task GetPublicNotes(EmptyNoteRequest request, IServerStreamWriter<NoteModel> responseStream, ServerCallContext context)
        {
            return base.GetPublicNotes(request, responseStream, context);   
        }

    }
}
