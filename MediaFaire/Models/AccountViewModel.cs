using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediaFaire.Resourse;

namespace MediaFaire.Models
{
    public class Login
    {
      
       [EmailAddress(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name ="EmailLabel",ResourceType =typeof(SharedResource))]
        public string Email { get; set; }



        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(SharedResource))]

        public string Password { get; set; }

    }

    public class Regeister
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [EmailAddress(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(SharedResource))]

        public string Email { get; set; }
        
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(SharedResource))]

        public string Password { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Compare("Password" )]
        [Display(Name = "ConfirmLabel", ResourceType = typeof(SharedResource))]

        public string ConfirmPassword { get; set; }
    }
}
