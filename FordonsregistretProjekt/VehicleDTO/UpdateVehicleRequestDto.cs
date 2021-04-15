using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class UpdateVehicleRequestDto
    {
        public string RegistrationNumber { get; set; }    
        public bool IsServiceBooked { get; set; }
        public bool VehicleStatus { get; set; }    
    }
}
