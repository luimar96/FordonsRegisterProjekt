using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;

namespace VehicleDomain.Vehicle.Interfaces
{
    public interface IVehicleService
    {
       float GetYearlyFeeByType(IVehicle vehicle);
    }
}
