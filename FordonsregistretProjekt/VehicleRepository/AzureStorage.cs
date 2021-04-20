using System;
using System.Collections.Generic;
using System.Linq;
using VehicleDomain;
using VehicleDomain.Interfaces;
using VehicleDomain.Vehicle.Interfaces;
using VehicleRepository.Interfaces;

namespace VehicleRepository
{
    public class AzureStorage : IVehicleRepository, IServiceRepository, IVehicleService
    {
        private readonly AzureStorageDataContext dataContext;
        public AzureStorage()
        {
            this.dataContext = new AzureStorageDataContext();
        }
        public void Create(IVehicle vehicle)
        {
            var vehicleRegNumExist = dataContext.Vehicles.Where(i => i.RegistrationNumber == vehicle.RegistrationNumber).FirstOrDefault();
            if (vehicleRegNumExist is null)
            {
                var newVehicle = new Vehicle()
                {
                    RegistrationNumber = vehicle.RegistrationNumber,
                    Model = vehicle.Model,
                    Brand = vehicle.Brand,
                    FirsTimeInTrafic = vehicle.FirsTimeInTrafic,
                    Weight = vehicle.Weight,
                    VehicleStatus = vehicle.VehicleStatus,
                    YearlyFee = vehicle.YearlyFee,


                };
                dataContext.Vehicles.InsertOnSubmit(newVehicle);
                dataContext.SubmitChanges();

            }
            else
                throw new Exception("Vehicle Exist alreaday");

        }

        public void Create(IService service)
        {
            var newService = new Service()
            {
                RegistrationNumber = service.RegistrationNumber,
                ServiceDate = service.ServiceDate,
                Description = service.Description
            };
            dataContext.Services.InsertOnSubmit(newService);
            dataContext.SubmitChanges();
        }

        public void CreateServices(IList<IService> services)
        {
            throw new NotImplementedException();
        }


        public void Delete(string regNum)
        {
            DeleteService(regNum);
            var deleteVehicle = dataContext.Vehicles.Where(i => i.RegistrationNumber == regNum).FirstOrDefault();
            if (deleteVehicle != null)
            {
                dataContext.Vehicles.DeleteOnSubmit(deleteVehicle);
                dataContext.SubmitChanges();
            }

        }

        public void DeleteService(string regNum)
        {
            IEnumerable<Service> services = dataContext.Services.Where(i => i.RegistrationNumber == regNum).ToList();

            dataContext.Services.DeleteAllOnSubmit(services);
            dataContext.SubmitChanges();
        }

        public void DeleteService(int id)
        {
            var deleteService = dataContext.Services.Where(i => i.Id == id).FirstOrDefault();

            dataContext.Services.DeleteOnSubmit(deleteService);
            dataContext.SubmitChanges();
        }

        public IEnumerable<IService> GetAllServices()
        {
            var services = new List<IService>();
            foreach (var entity in dataContext.Services.ToList())
            {
                IService domainService = ServiceFactory.CreateService(entity.Id, entity.RegistrationNumber, entity.ServiceDate, entity.Description, entity.IsCompleted);
                services.Add(domainService);
            }
            return services;
        }

        public IEnumerable<IVehicle> GetAllVehicles()
        {
            var vehicles = new List<IVehicle>();
            foreach (var entity in dataContext.Vehicles.ToList())
            {
                var isServiceBooked = dataContext.Services.Where(i => i.RegistrationNumber == entity.RegistrationNumber).Any();
                IVehicle domainVehicle = VehicleFactory.CreateVehicle(entity.RegistrationNumber, entity.Model, entity.Brand, (float)entity.Weight, Convert.ToDateTime(entity.FirsTimeInTrafic),
                                                                        Convert.ToBoolean(entity.VehicleStatus), (float)entity.YearlyFee, isServiceBooked);
                vehicles.Add(domainVehicle);
            }
            return vehicles;
        }

        //fel
        public IService GetById(int ID)
        {

            var service = dataContext.Services.Where(i => i.Id == ID).FirstOrDefault();

            if (service != null)
            {
                IService domainService = ServiceFactory.CreateService(service.Id, service.RegistrationNumber, service.ServiceDate, service.Description, service.IsCompleted);
                return domainService;
            }
            return null;
        }

        public IVehicle GetbyRegistration(string regnum)
        {
            var vehicle = dataContext.Vehicles.Where(i => i.RegistrationNumber == regnum).FirstOrDefault();
            if (vehicle != null)
            {
                var isServiceBooked = dataContext.Services.Where(i => i.RegistrationNumber == regnum).Any();

                IVehicle domainVehicle = VehicleFactory.CreateVehicle(vehicle.RegistrationNumber, vehicle.Model, vehicle.Brand, (float)vehicle.Weight, Convert.ToDateTime(vehicle.FirsTimeInTrafic),
                                                                        Convert.ToBoolean(vehicle.VehicleStatus), (float)vehicle.YearlyFee, isServiceBooked);


                return domainVehicle;
            }
            return null;
        }

        public float GetYearlyFeeByType(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }


        public IService Update(IService service)
        {
            var selectService = dataContext.Services.Where(i => i.Id == service.Id).FirstOrDefault();
            if (selectService != null)
            {
                selectService.ServiceDate = service.ServiceDate;
                selectService.Description = service.Description;
                selectService.IsCompleted = service.IsCompleted;
                dataContext.SubmitChanges();

            }
            return service;
        }

        public IVehicle UpdateVehicle(IVehicle vehicle)
        {
            var selectVehicle = dataContext.Vehicles.Where(i => i.RegistrationNumber == vehicle.RegistrationNumber).FirstOrDefault();
            if (selectVehicle != null)
            {
                var isServiceBokked = dataContext.Services.Where(i => i.RegistrationNumber == vehicle.RegistrationNumber).Any();

                selectVehicle.VehicleStatus = vehicle.VehicleStatus;
                isServiceBokked = vehicle.IsServiceBooked;
                dataContext.SubmitChanges();

            }
            return vehicle;
        }
    }
}
