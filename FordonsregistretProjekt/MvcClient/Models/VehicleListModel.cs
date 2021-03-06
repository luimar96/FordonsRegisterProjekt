using System;
using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{
    public class VehicleListModel
    {
        [Display(Name = "Register number")]
        [Required(ErrorMessage = "You need to fill a Register Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "You need to fill a Brand")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "You need to fill a Model")]
        public string VehicleModel { get; set; }

        [Display(Name = "Weight")]
        [Required(ErrorMessage = "You need to fill a Weight")]
        public float Weight { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "First time in trafic")]
        [Required(ErrorMessage = "You need to fill FirstTimeInTrafic")]
        public DateTime FirstTimeInTrafic { get; set; }

        [Display(Name = "VehicleStatus")]
        [Required(ErrorMessage = "You need to check vehiclel status")]
        public bool VehicleStatus { get; set; }

    }
}