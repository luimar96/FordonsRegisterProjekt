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
        string GetVehicles { get; }
    }
    public class LocalApiEndpoints : IApiEndpoints
    {
        public string CreateVehicle => "https://localhost:44377/api/createvehicle";
        public string GetVehicles => "https://localhost:44377/api/getvehicles";
        public string GetServices => "https://localhost:44377/api/getAllServices";
        public string CreateService => "https://localhost:44377/api/createService";
    }
}
