﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class FileController : Controller
    {
        private IUserFileInfoData _filesInfo;
        private IUserFileContentData _filesContent;

        public FileController(IUserFileInfoData filesInfo, IUserFileContentData filesContent)
        {
            _filesInfo = filesInfo;
            _filesContent = filesContent;
        }

        public ActionResult Details(Guid Id)
        {

            var file = _filesInfo.Get(Id);
            if(file == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new UserFileViewModel
            {
                Extension = file.Filename.Substring(file.Filename.LastIndexOf('.') + 1).ToUpper(),
                Filename = file.Filename,
                Size = file.Size,
                LastEdit = file.LastEdit,
                SharedUsers = new List<string> { "asdf", "fdsa" },
                FileId = file.FileId,
                Owner = file.Owner,
                UploadTime = file.UploadTime
            };
            return View(model);
            
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(UserFileEditViewModel model)
        {
            Guid fileId = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                if (model.FormFile != null && model.FormFile.Length > 0)
                {
                    byte[] file = GetFile(model.FormFile);
                    string filename = model.FormFile.FileName;
                    string contentType = model.FormFile.ContentType;
                    string extension = model.FormFile.FileName.Substring(filename.LastIndexOf('.'));
                    long size = model.FormFile.Length;
                    DateTime uploadTime = DateTime.Now;
                    DateTime lastEdit = DateTime.Now;
                    string owner = "Owner";

                    _filesContent.AddFileContent(file, contentType, fileId);
                    _filesInfo.AddFileInfo(filename, extension, size, uploadTime, lastEdit, owner, fileId);
                    return RedirectToAction("Details", new { id = fileId });
                }
            }
            return View(model);
        }

        private byte[] GetFile(IFormFile uploadedFile)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iformfile?view=aspnetcore-2.0
            byte[] file = null;

            if (uploadedFile != null &&
                (uploadedFile.FileName.Length > 0) && // have a file
                (uploadedFile.Length < 1024 * 1024)) // file is under 1 MB
            {
                file = new byte[uploadedFile.Length];
                uploadedFile.OpenReadStream().Read(file, 0, (int)uploadedFile.Length);
            }

            return file; // will be null if can't do it.
        }

        public FileResult Download(Guid Id)
        {
            var fileComponents = _filesContent.Get(Id);
            byte[] file = fileComponents.FileContent;
            string contentType = fileComponents.ContentType;
            return File(file,contentType);
        }
    }
}
