using GetAllVehicleDto_;
using MvcClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using VehicleDTO;
using static VehicleDTO.ServicesDto;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiEndpoints apiEndpoints;
        public HomeController()
        {
            apiEndpoints = new LocalApiEndpoints();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SearchVehiclee(string search)
        {

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.SearchVehicle + search).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<VehicleDto>(jsonString);                     
                       if(serviceResponse == null)
                    {
                        ViewBag.Message = "No vehicle found!";
                    }
                    return View(serviceResponse);
                }

            }
          
            return RedirectToAction("viewVehicles");
        }
       

        public ActionResult ViewVehicles()
        {
            var vehicles = new List<ViewVehicleModel>();
            ViewBag.Message = "Vehicle List";
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.GetVehicles).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var vehicleResponse = JsonConvert.DeserializeObject<GetAllVehicleDto>(jsonString);

                    foreach (var vehicle in vehicleResponse.Vehicles)
                    {
                        var vehicleListModel = new ViewVehicleModel
                        {
                            RegistranionNumber = vehicle.RegistranionNumber,
                            Model = vehicle.Model,
                            Brand = vehicle.Brand,
                            Weight = vehicle.Weight,
                            FirstTimeInTrafic = vehicle.FirstTimeInTrafic,
                            YearlyFee = vehicle.YearlyFee,
                            IsServiceBooked = vehicle.IsServiceBooked,
                            VehicleStatus = vehicle.VehicleStatus
                            
                        };
                        vehicles.Add(vehicleListModel);
                    }
                    ViewBag.Vehicles = vehicles;
                }

            }
            return View("viewVehicles", vehicles);
        }

        public ActionResult VehicleDetails(string regNum)
        {
           using(HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.SearchVehicle + regNum).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<VehicleDto>(jsonString);
                    return View(serviceResponse);
                }

            }
            return RedirectToAction("Index");
        }
       
        public ActionResult EditVehicle(string regNum)
        {

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.SearchVehicle + regNum).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<UpdateVehicleRequestDto>(jsonString);
                    return View(serviceResponse);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditVehicle(UpdateVehicleModel model)
        {

            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    var updateService = JsonConvert.SerializeObject(model);
                    var httpContent = new StringContent(updateService, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(new Uri(apiEndpoints.UpdateVehicle), httpContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }

            return View();
        }

        public ActionResult CreateVehicle()
        {
            ViewBag.Message = "Register Vehicle";

            return View();
        }

        [HttpPost]
        public ActionResult CreateVehicle(VehicleListModel model)
        {
            if (ModelState.IsValid)
            {
                var createVehicleRequest = new CreateVehicleRequestDto
                {
                    RegistrationNumber = model.RegistrationNumber,
                    Brand = model.Brand,
                    Model = model.VehicleModel,
                    Weight = model.Weight,
                    FirstTimeInTrafic = model.FirstTimeInTrafic,
                    VehicleStatus = model.VehicleStatus


                };
                string jsonCreateVehicle = JsonConvert.SerializeObject(createVehicleRequest);
                var httpContet = new StringContent(jsonCreateVehicle, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PostAsync(new Uri(apiEndpoints.CreateVehicle), httpContet).Result;
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return View("Error");
                }
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Register Vehicle";
            return View();
        }

        public ActionResult DeleteVehicle(string regNum)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(apiEndpoints.DeletVehicle + regNum).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<VehicleDto>(jsonString);
                    return View(serviceResponse);
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewServices()
        {
            var services = new List<ViewServicesModel>();
            ViewBag.Message = "Service list";
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.GetServices).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<GetAllServicesDto>(jsonString);
                    foreach (var service in serviceResponse.Services)
                    {
                        var serviceListModel = new ViewServicesModel
                        {
                            Id = service.Id,
                            RegistrationNumber = service.RegistrationNumber,
                            ServiceDate = service.ServiceDate,
                            Description = service.Description,
                            IsCompleted = service.IsCompleted
                        };
                        services.Add(serviceListModel);
                    }
                    ViewBag.Message = services;
                }
            }
            return View("ViewServices", services);
        }

        public ActionResult CreateService()
        {
            ViewBag.Message = "Create service";

            return View();
        }
        
        [HttpPost]
        public ActionResult CreateService(ServicesListModel model)
        {
            if (ModelState.IsValid)
            {
                var createServiceRequest = new CreateServiceRequestDto
                {                    
                    RegistrationNumber = model.RegistrationNumber,
                    ServiceDate = model.ServiceDate,
                    Description = model.Description,
                };
                string jsonCreateVehicle = JsonConvert.SerializeObject(createServiceRequest);
                var httpContet = new StringContent(jsonCreateVehicle, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PostAsync(new Uri(apiEndpoints.CreateService), httpContet).Result;
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return View("Error");
                }
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Create Service";
            return View();
        }

        public ActionResult ServiceDetails(int id)
        {
            
            using(HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.GetServiceId + id).Result;
                if(response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServicesDto>(jsonString);
                    return View(serviceResponse);
                }
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditService(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiEndpoints.GetServiceId + id).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<UpdateServiceRequestDto>(jsonString);
                    return View(serviceResponse);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditService(UpdateServiceListModel model)
        {
            if(ModelState.IsValid)
            {
                using(HttpClient client = new HttpClient())
                {
                    var updateService = JsonConvert.SerializeObject(model);
                    var httpContent = new StringContent(updateService, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(new Uri(apiEndpoints.UpdateService), httpContent).Result;
                    if(response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
               
            }
          
            return View();
        }
    }

}