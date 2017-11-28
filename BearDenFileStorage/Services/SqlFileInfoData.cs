using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class SqlFileInfoData : IUserFileInfoData
    {
        private FileStorageDbContext _db;
        public SqlFileInfoData(FileStorageDbContext db)
        {
            _db = db;
        }

        public void AddFileContent(byte[] file, Guid fileId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void AddFileInfo(string filename, string extension, long size, DateTime uploadTime, DateTime lastEdit, string owner, Guid fileId)
        {
            var newFileInfo = new UserFileInfo {
                Filename = filename,
                FileId = fileId,
                LastEdit = lastEdit,
                Owner = owner,
                Size = size,
                UploadTime = uploadTime
            };

            _db.Add<UserFileInfo>(newFileInfo);
            
        }

        public UserFileInfo Get(Guid Id)
        {
            return _db.Find<UserFileInfo>(Id);
        }

        public IEnumerable<UserFileInfo> GetAll()
        {
            return _db.FilesInfo;
        }

        public IEnumerable<UserFileInfo> GetByUser(string owner)
        {
            return _db.FilesInfo.Where(file => file.Owner == owner);
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
