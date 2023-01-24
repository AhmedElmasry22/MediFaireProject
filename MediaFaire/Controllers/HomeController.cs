using MediaFaire.Data;
using MediaFaire.Helper;
using MediaFaire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MediaFaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AplicationDbContext db;
        private readonly IMailHelper mail;
        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } set { } }

        public HomeController(ILogger<HomeController> logger,AplicationDbContext db,IMailHelper mail)
        {
            _logger = logger;
            this.db = db;
            this.mail = mail;
        }

        public IActionResult Index()
        {

            var result = db.uploads.OrderByDescending(u => u.UploadCount)
            .Take(3)
                .Select(u => new UploadsViewModel
            {
                UploadCount = u.UploadCount,
                Id = u.Id,
                UploadDate = u.UploadDate,
                FileName = u.FileName,
                ContentSize = u.Size,
                ContentType = u.ContentType

            });

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

      public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                await db.contacts.AddAsync(new Data.Contact
                {
                    Email = model.Email,
                    Subject = model.Subject,
                    Messege=model.Message,
                    UserId=UserId,
                    Name=model.Name

                }) ;
              await  db.SaveChangesAsync();

                StringBuilder sp = new StringBuilder();
                
                sp.AppendFormat("Name {0}", model.Name);
                sp.AppendFormat("Email: {0}", model.Email);
                sp.AppendLine();
                sp.AppendFormat("Supject: {0}", model.Subject);
                sp.AppendFormat("Message: {0}", model.Message);



                mail.SendMail(new InputEmail
                {
                    Subject = "You Have Un Read Messege",
                    Email = model.Email,
                    Message = sp.ToString()
                }) ;
                return RedirectToAction("Contact");
            }
            return View(model);
        }
        public IActionResult SetLang(string Lang,string returnUrl )
        {

              Response.Cookies.Append(
              CookieRequestCultureProvider.DefaultCookieName,
              CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Lang)),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
   );
            if (!string.IsNullOrEmpty(returnUrl))

            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("index");
        }



    }
}
