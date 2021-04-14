using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDomain.Interfaces;

namespace VehicleDomain.Vehicle
{
    public class MediumWeightVehicle : IVehicle
    {

        private string registrantionNumber { get; set; }
        private string brand { get; set; }
        private string vehicleType { get; set; }
        private string model { get; set; }
        private float weight { get; set; }
        private DateTime firstTimeInTrafic { get; set; }
        private bool vehicleStatus { get; set; }
        private bool isServiceBooked { get; set; }
        private IList<IService> serviceHistory { get; set; } = new List<IService>();
        private float yearlyFee { get; set; }

        public string RegistrationNumber => registrantionNumber;
        public string Model => model;
        public string Brand => brand;
        public string VehicleType { get; set; }
        public float Weight => weight;
        public DateTime FirsTimeInTrafic => firstTimeInTrafic;
        public bool VehicleStatus => vehicleStatus;
        public bool IsServiceBooked => isServiceBooked;
        public IList<IService> ServiceHistory => serviceHistory;
        public float YearlyFee => yearlyFee;
        public MediumWeightVehicle(string registernumber, string brand, string model, float weight, DateTime firstTimeInTrafic, float yearlyFee, bool vehicleStatus, bool isServicebooked)
        {
            this.registrantionNumber = registernumber;
            this.brand = brand;
            this.model = model;
            this.weight = weight;
            this.firstTimeInTrafic = firstTimeInTrafic;
            this.isServiceBooked = isServicebooked;
            this.vehicleStatus = vehicleStatus;
            if (yearlyFee == 0)
            {
                YearlyFee_(yearlyFee);
            }
            else
                this.yearlyFee = yearlyFee;
        }
        public MediumWeightVehicle(string registernumber, string brand, string model, float weight, DateTime firstTimeInTrafic, bool vehicleStatus, float yearlyFee, string vehicletype,
                                   bool isServicebooked)
        {
            this.registrantionNumber = registernumber;
            this.brand = brand;
            this.vehicleType = vehicletype;
            this.model = model;
            this.weight = weight;
            this.firstTimeInTrafic = firstTimeInTrafic;
            this.yearlyFee = yearlyFee;
            this.isServiceBooked = isServicebooked;
            this.vehicleType = vehicleType;
            this.vehicleStatus = vehicleStatus;

        }

        public void VehicleStatusOn()
        {
            this.vehicleStatus = true;
        }
        public void VehicleStatusOff()
        {
            this.vehicleStatus = false;
        }
        public string Vehicletype(string type)
        {
            this.vehicleType = type + "Light weight vehicle";
            return vehicleType;
        }
        public IList<IService> ServicesHistory()
        {
            return null;
        }
        public void YearlyFee_(float yearlyFee)
        {
            this.yearlyFee = yearlyFee + 1800;

        }
    }
}
