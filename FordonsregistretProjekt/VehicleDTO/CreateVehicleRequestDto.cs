using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class CreateVehicleRequestDto
    {
        public string RegistrationNumber { get; set; }   
        public string Brand { get; set; }     
        public string Model { get; set; }
        public float Weight { get; set; }
        public DateTime FirstTimeInTrafic { get; set; }
        public bool IsServiceBooked { get; set; }
        public bool VehicleStatus { get; set; }
        public float YearlyFee { get; set; }
    }
}
