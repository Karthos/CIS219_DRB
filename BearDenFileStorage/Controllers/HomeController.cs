using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class HomeController : Controller
    {
        private IUserFileInfoData _files;
        public HomeController(IUserFileInfoData files)
        {
            _files = files;
        }

        public ViewResult Index()
        {
            var model = _files.GetAll().Select(file => 
            new UserFileViewModel {
                Extension = file.Filename.Substring(file.Filename.LastIndexOf('.')+1).ToUpper(),
                Filename = file.Filename,
                Size = file.Size,
                LastEdit = file.LastEdit,
                SharedUsers = new List<string> { "asdf","fdsa"},
                FileId = file.FileId,
                Owner = file.Owner,
                UploadTime = file.UploadTime
            });
            return View(model);
        }

        

        public string Settings()
        {
            return "Settings";
        }
    }
}
