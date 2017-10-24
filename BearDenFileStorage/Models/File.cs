using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class File
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Owner { get; set; }
        public List<string> SharedUsers { get; set; }
    }
}
