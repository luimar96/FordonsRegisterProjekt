using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class ServicesDto
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public class GetAllServicesDto
        {
            public IList<ServicesDto> Services { get; set; } = new List<ServicesDto>();
        }
    }
}
