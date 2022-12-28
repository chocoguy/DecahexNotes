using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using grpcbackend.Database;
using grpcbackend.Models;
using MongoDB.Driver;

namespace grpcbackend.Services
{
    public class FileService : Filep.FilepBase
    {
        private readonly DB _db;

        public FileService(DB db)
        {
            _db = db;
        }  

        //public override async Task GetPublicFiles(emptyFileRequest request, IServerStreamWriter<FileModel> responseStream, ServerCallContext context)
        //{
        //    List<Models.File> files = await _db.filesCollection.Find(_ => true).ToListAsync();

        //    foreach (Models.File currentFile in files)
        //    {
        //        FileModel fileModel = new();
        //        fileModel.Id = currentFile._id;
        //        fileModel.FileId = currentFile.Id;
        //        fileModel.UserId = currentFile.UserId;
        //        fileModel.Title = currentFile.Title;
        //        fileModel.Link = currentFile.Link;
        //        fileModel.ShareKey = currentFile.ShareKey;
        //        fileModel.Added = new Timestamp();
        //        fileModel.Views = currentFile.Views;
        //        fileModel.Size = currentFile.Size;
        //        fileModel.FileType = currentFile.FileType;
        //        await responseStream.WriteAsync(fileModel);
        //    }
        //}
    }
}
