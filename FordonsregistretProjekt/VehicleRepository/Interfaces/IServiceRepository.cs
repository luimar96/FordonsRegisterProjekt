using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;

namespace VehicleRepository.Interfaces
{
    public interface IServiceRepository
    {
        void Create(IService service);
        IService GetById(int id);
        IEnumerable<IService> GetAllServices();
        IService Update(IService service);
        void Delete(string id);
    }
}
