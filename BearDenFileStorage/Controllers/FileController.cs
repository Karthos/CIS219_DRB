using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class FileController : Controller
    {
        private IFileData _files;
        public FileController(IFileData files)
        {
            _files = files;
        }

        public ViewResult Details()
        {
            var model = _files.GetAll();

            return View(model);
            
        }

        public string Download()
        {
            return "Downloading...";
        }
    }
}
