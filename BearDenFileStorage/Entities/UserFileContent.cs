using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class UserFileContent
    {
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }

        [Key]
        public Guid FileId { get; set; }
    }
}
