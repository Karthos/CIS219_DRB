using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class UserFileEditViewModel
    {
        [Required]
        public IFormFile FormFile { get; set; }
    }
}
