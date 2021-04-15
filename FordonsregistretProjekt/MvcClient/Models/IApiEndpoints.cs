using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcClient.Models
{
    public interface IApiEndpoints
    {
        string CreateService { get; }
        string GetServices { get; }
        string CreateVehicle { get; }
        string SearchVehicle { get; }
        string GetVehicles { get; }
        string UpdateVehicle { get; }
        string UpdateService { get; }
        string GetServiceId { get; }
        string DeletVehicle { get; }

    }
    public class LocalApiEndpoints : IApiEndpoints
    {
        public string CreateVehicle => "https://localhost:44377/api/createvehicle";
        public string GetVehicles => "https://localhost:44377/api/getvehicles";
        public string SearchVehicle => "https://localhost:44377/api/searchvehicle/";
        public string UpdateVehicle => "https://localhost:44377/api/updateVehicle";
        public string DeletVehicle => "https://localhost:44377/api/deletevehicle/";
        public string GetServices => "https://localhost:44377/api/getAllServices";
        public string CreateService => "https://localhost:44377/api/createService";
        public string UpdateService => "https://localhost:44377/api/updateservice";
        public string GetServiceId => "https://localhost:44377/api/searcheservice/";
    }
}
