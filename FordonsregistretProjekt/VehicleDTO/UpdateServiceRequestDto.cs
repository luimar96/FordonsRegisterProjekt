using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class UpdateServiceRequestDto
    {
        public int Id { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public bool Iscompleted { get; set; }
    }
}
