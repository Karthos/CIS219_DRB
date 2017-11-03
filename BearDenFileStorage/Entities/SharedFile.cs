using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class SharedFile
    {
        [Key]
        public Guid FileId { get; set; }
        [Key]
        public Guid UserId { get; set; }
    }
}
