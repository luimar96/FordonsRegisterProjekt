using GetAllVehicleDto_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleDomain;
using VehicleDomain.Interfaces;
using VehicleDomain.Vehicle.Interfaces;
using VehicleDTO;
using VehicleRepository;
using VehicleRepository.Interfaces;
using static VehicleDTO.ServicesDto;

namespace FordonsregistretProjekt.Controllers
{
    public class VehicleApiController : ApiController
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IVehicleService vehicleService;
        public VehicleApiController( IVehicleRepository vehicleRepository, IServiceRepository serviceRepository, IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
            this.serviceRepository = serviceRepository;
            this.vehicleRepository = vehicleRepository;
        }
        [HttpPost]
        [Route("api/createvehicle")]
        public IHttpActionResult CreateVehicle(CreateVehicleRequestDto requestDto)
        {
            IVehicle vehicle = VehicleFactory.CreateVehicle(requestDto.RegistrationNumber,
                                                             requestDto.Model,
                                                             requestDto.Brand,
                                                             requestDto.Weight, requestDto.FirstTimeInTrafic,
                                                             requestDto.VehicleStatus, requestDto.YearlyFee,requestDto.IsServiceBooked);
            vehicleRepository.Create(vehicle);
            return Ok();

        }

        [HttpPost]
        [Route("api/createService")]
        public IHttpActionResult CreateService(CreateServiceRequestDto requestDto)
        {
           
            IService service = ServiceFactory.CreateService(requestDto.RegistrationNumber, requestDto.ServiceDate, requestDto.Description);

            serviceRepository.Create(service);
           
            return Ok();
        }
        [HttpPost]
        [Route("api/createServices")]
        public IHttpActionResult CreateServices(CreateServiceRequestDto requestDto)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/getAllServices")]
        public IHttpActionResult GetAllServices()
        {
            var response = new GetAllServicesDto();
            foreach (var service in serviceRepository.GetAllServices())
            {
                response.Services.Add(new ServicesDto()
                {
                    Id = service.Id,
                    RegistrationNumber = service.RegistrationNumber,
                    ServiceDate = service.ServiceDate,
                    Description = service.Description,
                    IsCompleted = service.IsCompleted
                });
                
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("api/updateservice")]
        public IHttpActionResult UpdateService(UpdateServiceRequestDto requestDto)
        {
            IService service = serviceRepository.GetById(requestDto.Id);
            service.Update(requestDto.ServiceDate,requestDto.Description,requestDto.Iscompleted);
            serviceRepository.Update(service);
            return Ok();
        }
        [HttpGet]
        [Route("api/searcheservice/{id}")]
        public IHttpActionResult SearchService(int id)
        {
            var service = serviceRepository.GetById(id);
            return Ok(service);
        }

        [HttpPut]
        [Route("api/updateVehicle")]
        public IHttpActionResult UpdateVechile(UpdateVehicleRequestDto requestDto)
        {
            IVehicle vehicle = vehicleRepository.GetbyRegistration(requestDto.RegistrationNumber);
            vehicle.Update(requestDto.VehicleStatus, requestDto.IsServiceBooked);
            vehicleRepository.UpdateVehicle(vehicle);
            return Ok();
        }

        [HttpGet]
        [Route("api/searchvehicle/{regNum}")]
        public IHttpActionResult SearchVehicle(string regNum)
        {
            var vehicle = vehicleRepository.GetbyRegistration(regNum);

            return Ok(vehicle);
        }

        [HttpGet]
        [Route("api/getvehicles")]
        public IHttpActionResult GetVehicle()
        {
            var reponse = new GetAllVehicleDto();
            foreach (var vehicle in vehicleRepository.GetAllVehicles())
            {
                reponse.Vehicles.Add(new VehicleDto()
                {
                    RegistranionNumber = vehicle.RegistrationNumber,
                    Model = vehicle.Model,
                    Brand = vehicle.Brand,
                    Weight = vehicle.Weight,
                    FirstTimeInTrafic = vehicle.FirsTimeInTrafic,
                    VehicleStatus = vehicle.VehicleStatus,
                    YearlyFee = vehicle.YearlyFee,
                    IsServiceBooked = vehicle.IsServiceBooked
                });

            }
            return Ok(reponse);
        }
        [HttpDelete]
        [Route("api/deletevehicle/{regNum}")]
        public IHttpActionResult DeleteVehicle(string regNum)
        {
           vehicleRepository.Delete(regNum);
            return Ok();
        }

      
    }
}
