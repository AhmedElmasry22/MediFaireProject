using MediaFaire.Data;
using MediaFaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Services
{
   public interface IUploadServices
    {
        IQueryable<UploadsViewModel> GetAllBy(string id);
        IQueryable<UploadsViewModel> GetAll();

        Task<Uploads> FindUpload( string id);
        Task Create(InputUpload model);
        IQueryable<UploadsViewModel> Search(string text);
        Task Delete(string id);
        Task Download(string name);
    }
}
