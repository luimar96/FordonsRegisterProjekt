using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcClient.Models
{
    public class UpdateVehicleModel
    {
        public string RegistrationNumber { get; set; }           
        public bool IsServiceBooked { get; set; }
        public bool VehicleStatus { get; set; }
     
    }
}