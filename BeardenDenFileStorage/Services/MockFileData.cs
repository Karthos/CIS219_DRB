using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class MockFileData : IFileData
    {
        private IEnumerable<File> _files;

        public MockFileData()
        {
            var file1 = new FileInfo("./Users/Alice/example.txt");
            var file2 = new DirectoryInfo("./Users/Alice/scripts");

            
            _files = new List<File>
            {
                new File {
                    Filename = file1.Name,
                    Extension = file1.Extension,
                    Size =file1.Length,
                    Created =file1.CreationTime,
                    LastModified =file1.LastWriteTime,
                    Owner = file1.Directory.Name,
                    SharedUsers = new List<string> { "Bob", "Eve" } },

                new File {
                    Filename = file2.Name,
                    Extension = file2.Extension,
                    Created =file2.CreationTime,
                    LastModified =file2.LastWriteTime,
                    SharedUsers = null
                    }


            };
        }

        public IEnumerable<File> GetAll()
        {
            return _files;
        }

    }
}
