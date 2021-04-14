using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcClient.Models
{
    public class ModelList
    {
        public string RegistranionNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Weight { get; set; }
        public DateTime FirstTimeInTrafic { get; set; }     
        public bool VehicleStatus { get; set; }
       
    }
}