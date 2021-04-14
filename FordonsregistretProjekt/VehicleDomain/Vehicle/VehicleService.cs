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

        public float GetYearlyFeeByType(IVehicle vehicle)
        {
           if(vehicle is LightWeightVehicle)
            {
                return 1200;
            }
            return 0;
        }
    }
}
