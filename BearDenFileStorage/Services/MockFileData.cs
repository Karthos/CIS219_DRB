using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class MockFileData : IUserFileInfoData
    {
        private List<UserFileInfo> _filesInfo;
        private List<UserFileContent> _filesContent;
        public MockFileData()
        {
            var file1 = new FileInfo(@"J:\Documents\Visual Studio 2017\Projects\BearDenFileStorage\BearDenFileStorage\TextFile.txt");
            var file2 = new FileInfo(@"J:\Documents\Visual Studio 2017\Projects\BearDenFileStorage\BearDenFileStorage\TextFile1.py");


            _filesInfo = new List<UserFileInfo>
            {
                new UserFileInfo{
                    Filename = file1.Name,
                    LastEdit = file1.LastWriteTime,
                    Owner = "user1",
                    UploadTime = file1.CreationTime,
                    FileId = Guid.NewGuid(),
                    Size = file1.Length
                },


                new UserFileInfo {
                    Filename = file2.Name,
                    LastEdit = file2.LastWriteTime,
                    FileId = Guid.NewGuid(),
                    Owner = "user2",
                    UploadTime = file2.CreationTime,
                    Size = file2.Length
                    }


            };

            _filesContent = new List<UserFileContent>
            {
                new UserFileContent
                {
                    FileContent = File.ReadAllBytes(file1.FullName),
                    FileId = _filesInfo[0].FileId
                },
                new UserFileContent
                {
                    FileContent = File.ReadAllBytes(file2.FullName),
                    FileId = _filesInfo[1].FileId
                }
            };
        }

        public void AddFileContent(byte[] file, Guid fileId, Guid userId)
        {
            _filesContent.Add(new UserFileContent
            {
                FileContent = file,
                FileId = fileId,
            });
        }

       

        public void AddFileInfo(string filename, string extension, long size, DateTime uploadTime, DateTime lastEdit, string owner, Guid fileId)
        {
            _filesInfo.Add(
                new UserFileInfo
                {
                    Filename = filename,
                    Size = size,
                    UploadTime = DateTime.Now,
                    LastEdit = DateTime.Now,
                    Owner = owner,
                    FileId = fileId
                });
        }

        public UserFileInfo Get(Guid Id)
        {
            return _filesInfo.FirstOrDefault(f => f.FileId == Id);
        }

        public IEnumerable<UserFileInfo> GetAll()
        {
            return _filesInfo;
        }

    }
}
