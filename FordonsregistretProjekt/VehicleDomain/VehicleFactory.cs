using System;
using System.Collections.Generic;
using VehicleDomain.Interfaces;
using VehicleDomain.Vehicle;

namespace VehicleDomain
{
    public static class VehicleFactory
    {
        //Här ska den skapa en rigbester och välja vilken fordons typ det är.
        public static IVehicle CreateVehicle(string registernumber, string model, string brand,   float weight, DateTime firstTimeInTrafic, bool vehicleStatus,float yearlyFee,bool isServiceBooked)
        {
            switch(weight)
            {
                case float n when (n <= 1800):
                    return new LightWeightVehicle(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);

                case float n when (n >= 2500):
                    return new HeavyWeightVehilce(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);
                default:
                    return new MediumWeightVehicle(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);
            }

           
        }
        public static IVehicle CreateVehicle(string registernumber, string model, string brand, float weight, DateTime firstTimeInTrafic, bool vehicleStatus, float yearlyFee, string vehicleType,
                                               bool isServiceBooked)
        {

            switch (weight)
            {
                case float n when (n <= 1800):
                    return new LightWeightVehicle(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);

                case float n when (n >= 2500):
                    return new HeavyWeightVehilce(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);
                default:
                    return new MediumWeightVehicle(registernumber, brand, model, weight, firstTimeInTrafic, yearlyFee, vehicleStatus, isServiceBooked);
            }
        }

    }
}
