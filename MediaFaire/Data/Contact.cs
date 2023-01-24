using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string  Email { get; set; }
        public string Name { get; set; }

        public string Subject { get; set; }
        public string Messege { get; set; }
        [ForeignKey("User Id")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

    }
}
