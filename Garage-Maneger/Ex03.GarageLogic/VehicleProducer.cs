using System;

namespace Ex03.GarageLogic
{
    public class VehicleProducer
    {
        public static Vehicle CreateVehicle(Vehicle.eVehicleTypes i_VehicleType, string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType, string i_ManufacturerName)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleTypes.Car:
                    {
                        newVehicle = new Car(i_ModelName, i_LicensePlate, i_EngineType, i_ManufacturerName);
                        break;
                    }
                case Vehicle.eVehicleTypes.Motorcycle:
                    {
                        newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, i_EngineType, i_ManufacturerName);
                        break;
                    }
                case Vehicle.eVehicleTypes.Truck:
                    {
                        newVehicle = new Truck(i_ModelName, i_LicensePlate, i_EngineType, i_ManufacturerName);
                        break;
                    }
            }

            return newVehicle;
        }
    }
}
