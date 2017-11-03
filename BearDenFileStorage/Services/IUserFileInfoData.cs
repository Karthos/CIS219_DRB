using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public interface IUserFileInfoData
    {
        IEnumerable<UserFileInfo> GetAll();
        UserFileInfo Get(Guid Id);
        void AddFileContent(byte[] file, Guid fileId, Guid userId);
        void AddFileInfo(string filename, string extension, long size, DateTime uploadTime, DateTime lastEdit, string owner, Guid fileId);
    }
}
