using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class UserFileViewModel
    {
        public string Filename { get; set; }
        public long Size { get; set; }
        public DateTime UploadTime { get; set; }
        public DateTime LastEdit { get; set; }
        public string Extension { get; set; }
        public string Owner { get; set; }
        public List<string> SharedUsers { get; set; }
        public Guid FileId { get; set; }
    }
}
