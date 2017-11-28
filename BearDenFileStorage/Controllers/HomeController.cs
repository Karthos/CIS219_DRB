using Microsoft.AspNetCore.Identity;
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
        private UserManager<User> _userManager;
        public HomeController(IUserFileInfoData files,UserManager<User> userManager)
        {
            _files = files;
            _userManager = userManager;
        }

        public ViewResult Files()
        {
            var model = _files.GetByUser(_userManager.GetUserName(HttpContext.User)).Select(file => 
            new UserFileViewModel {
                Extension = file.Filename.Substring(file.Filename.LastIndexOf('.')+1).ToUpper(),
                Filename = file.Filename,
                Size = file.Size,
                LastEdit = file.LastEdit,
                
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
