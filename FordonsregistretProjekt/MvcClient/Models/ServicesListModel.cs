using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcClient.Models
{
    public class ServicesListModel
    {
        [Display(Name = "Register number")]
        [Required(ErrorMessage = "You need to fill a Register Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Service date")]
        [Required(ErrorMessage = "You need to fill Service date")]
        public DateTime ServiceDate { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You need to fill a Description")]
        public string Description { get; set; }
    }
}