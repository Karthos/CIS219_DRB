using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class SqlFileContentData : IUserFileContentData
    {
        private FileStorageDbContext _db;
        public SqlFileContentData(FileStorageDbContext db)
        {
            _db = db;
        }


        public void AddFileContent(byte[] file, string contentType, Guid fileId)
        {
            var newFileContent = new UserFileContent
            {
                FileContent = file,
                ContentType = contentType,
                FileId = fileId
            };

            _db.Add<UserFileContent>(newFileContent);
            _db.SaveChanges();
        }

        public UserFileContent Get(Guid Id)
        {
            return _db.Find<UserFileContent>(Id);
        }

        IEnumerable<UserFileContent> IUserFileContentData.GetAll()
        {
            return _db.FilesContent;
        }
    }
}
