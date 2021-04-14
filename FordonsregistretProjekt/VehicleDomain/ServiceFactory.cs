using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;
using VehicleDomain.Service;

namespace VehicleDomain
{
   public static class ServiceFactory
    {
        public static IService CreateService(string regnum, DateTime serviceDate, string description)
        {
            return new Service.Service(regnum, serviceDate, description);
        }
        public static IService CreateService(int id, string regNum, DateTime serviceDate, string description,bool isCompleted)
        {
            return new Service.Service(id,regNum, serviceDate, description,isCompleted);
        }
    }
}
