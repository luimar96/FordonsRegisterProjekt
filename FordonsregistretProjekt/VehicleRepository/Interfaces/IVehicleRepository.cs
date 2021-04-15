using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;

namespace VehicleRepository
{
    public interface IVehicleRepository
    {
        void Create(IVehicle vehicle);
        IVehicle GetbyRegistration(string regnum);
      
        IEnumerable<IVehicle> GetAllVehicles();
        IVehicle UpdateVehicle(IVehicle vehicle);
        void Delete(string regNum);
    }
}
