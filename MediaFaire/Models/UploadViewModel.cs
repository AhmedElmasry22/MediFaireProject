using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Models
{
    public class InputFile
    {
        [Required]
        public IFormFile File { get; set; }

    }
    public class InputUpload{
         public string FileName { get; set; }
         public string ContentType { get; set; }
         public long Size { get; set; }
         public string UserID { get; set; }




    }

    public class UploadsViewModel
    { 
        public string FileName { get; set; }
        public decimal ContentSize { get; set; }

        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public int UploadCount { get; set; }
        public string Id { get; set; }
    }
}
