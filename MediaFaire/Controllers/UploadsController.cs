using MediaFaire.Data;
using MediaFaire.Models;
using MediaFaire.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediaFaire.Controllers
{
    [Authorize]
    
    public class UploadsController : Controller

    {

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } set { } }

        private readonly IUploadServices up;
        private readonly IWebHostEnvironment webHost;

        public UploadsController(IUploadServices up, IWebHostEnvironment webHost)
        {
            this.up = up;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            var result = up.GetAllBy(UserId);

                
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputFile model)
        {
            if (ModelState.IsValid)
            {
                var orignalName = model.File.FileName;
                var extenstion = Path.GetExtension(model.File.FileName);
                
                var root = webHost.WebRootPath;
                var fullPath = Path.Combine(root, "Uploads", orignalName);
                using (var file = System.IO.File.Create(fullPath))
                {
                    await model.File.CopyToAsync(file);
                }


                await up.Create(new InputUpload
                {
                    FileName = model.File.FileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                    UserID = UserId

                }) ;
                 


                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUpload(string id)
        {
            Uploads model = await up.FindUpload(id);

            if (model == null)
            {
                return NotFound();
            }

            if (model.UserID != UserId)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("DeleteUpload")]

        public async Task<IActionResult> DeleteConfirmation(string id)
        {
             await  up.Delete(id);
            return RedirectToAction("Index");
        }

        
        public List<UploadsViewModel> GetResult(IQueryable<UploadsViewModel> result, int requiredPage, decimal rows)
        {

            const int pageSize = 2;

            requiredPage = requiredPage < 1 ? 1 : requiredPage;
           
            int skipCount = (requiredPage - 1) * pageSize;


            var pageCount = Math.Ceiling(rows / pageSize);
            requiredPage = requiredPage > pageCount ? 1 : requiredPage;

            var model = result.Skip(skipCount).Take(pageSize).ToList();

            ViewBag.currentPage = requiredPage;
            ViewBag.pageCount = pageCount;
            return model;

            
        }
        
        
        
        
        [HttpPost]
        [AllowAnonymous]
        public  IActionResult SearchUploads(string searchText, int requiredPage=1)
        {
            var result = up.Search(searchText);
            var rows = result.Count();
            var model = GetResult(result, requiredPage, rows);

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Browse(int requiredPage=1)
        {


            var result = up.GetAll();
            decimal rows = result.Count();

            var model = GetResult(result, requiredPage,rows);
           

            return View(model);
        }
  
       [HttpGet]
        public IActionResult Download(string FileName)
        {
            up.Download(FileName);
            var path = "~/Uploads/" + FileName;
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cahe");
            return File(path, "image/jpeg",FileName);
        }
    }

   
}
