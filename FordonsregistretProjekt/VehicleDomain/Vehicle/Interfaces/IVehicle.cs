using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDomain.Interfaces
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Model { get;  }
        string Brand { get;  }
        string VehicleType { get; set; }
        float Weight { get;  }
        DateTime FirsTimeInTrafic { get; }
        bool VehicleStatus { get;  }
        bool IsServiceBooked { get;  }
        IList<IService> ServiceHistory { get; }
        float YearlyFee { get; }
       

    }
}
