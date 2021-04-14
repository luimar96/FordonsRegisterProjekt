using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class CreateServiceRequestDto
    {
        public string RegistrationNumber { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }

    }
}
