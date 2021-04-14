using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;
using VehicleDomain.Vehicle.Interfaces;

namespace VehicleDomain.Vehicle
{
    public class VehicleService : IVehicleService
    {
        public void CreateServices(IList<IService> services)
        {
           
        }

        public float GetYearlyFeeByType(IVehicle vehicle)
        {
            if (vehicle is LightWeightVehicle)
            {
                return 1200;
            }
            else if (vehicle is MediumWeightVehicle)
                return 1800;
            else
                return 4500;
        }
    }
}
