using MediaFaire.Data;
using MediaFaire.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Services
{
    public class UploadService : IUploadServices
    {
        private readonly AplicationDbContext db;

        public UploadService(AplicationDbContext db) {
            this.db = db;
        }
        public async Task Create(InputUpload model)
        {
            await db.uploads.AddAsync(new Uploads
            {
                FileName = model.FileName,
                ContentType = model.ContentType,
                Size = model.Size,
                UserID = model.UserID,
                UploadDate=DateTime.Now

            }) ;
            db.SaveChanges();

        }

        public async Task Delete(string id)
        {
          var model=  await  FindUpload(id);
          db.uploads.Remove(model);
          db.SaveChanges();

        }

        public IQueryable<UploadsViewModel> GetAll()
        {
           var result= db.uploads.OrderByDescending(u => u.UploadDate)
                 .Select(u => new UploadsViewModel
                 {
                     UploadCount = u.UploadCount,
                     Id = u.Id,
                     UploadDate = u.UploadDate,
                     FileName = u.FileName,
                     ContentSize = u.Size,
                     ContentType = u.ContentType

                 });
            return result;
        }

        public IQueryable<UploadsViewModel> GetAllBy(string id)
        {
            var result =  db.uploads.Where(u => u.UserID == id).OrderByDescending(u=>u.UploadDate)
                .Select(u=>new UploadsViewModel
                {
                    Id = u.Id,
                    FileName = u.FileName,
                    ContentSize = u.Size,
                    ContentType = u.ContentType,
                    UploadDate = u.UploadDate,

                });
            return result;
        }

        public async Task<Uploads> FindUpload(string id)

        {
            var model = await db.uploads.FindAsync(id);
            return model;


        }

        public   IQueryable<UploadsViewModel> Search(string searchText)
        {
            var result =  db.uploads.Where(u => u.FileName.Contains(searchText))
                           .Select(u => new UploadsViewModel
                           {
                               UploadCount = u.UploadCount,
                               Id = u.Id,
                               UploadDate = u.UploadDate,
                               FileName = u.FileName,
                               ContentSize = u.Size,
                               ContentType = u.ContentType

                           });
            return result;
        }

        public async Task Download(string name)
        {
            var model = await db.uploads.FirstOrDefaultAsync(u => u.FileName ==name);
            model.UploadCount++;
            db.uploads.Update(model);
            db.SaveChanges();

        }
    }
}
