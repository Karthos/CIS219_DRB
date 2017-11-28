using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public interface IUserFileContentData
    {
        IEnumerable<UserFileContent> GetAll();
        UserFileContent Get(Guid Id);
        void AddFileContent(byte[] file, string contentType, Guid fileId);
        int Commit();
    }
}
