using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Data
{
    public class Uploads
    {

        public Uploads()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string UserID { get; set; }

        public DateTime UploadDate { get; set; }
        public int UploadCount { get; set; }


        public IdentityUser User { get; set; }


    }
}
