using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class HomeController : Controller
    {
        private IFileData _files;
        public HomeController(IFileData files)
        {
            _files = files;
        }

        public ViewResult Index()
        {
            var model = _files.GetAll();
            return View(model);
        }

        public ViewResult Upload()
        {
            return View();
        }

        public string Settings()
        {
            return "Settings";
        }
    }
}
