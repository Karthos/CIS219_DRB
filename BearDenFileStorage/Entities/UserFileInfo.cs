using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class UserFileInfo
    {
        public string Filename { get; set; }
        public long Size { get; set; }
        public DateTime UploadTime { get; set; }
        public DateTime LastEdit { get; set; }
        public string Owner { get; set; }

        [Key]
        public Guid FileId { get; set; }
    }
}
