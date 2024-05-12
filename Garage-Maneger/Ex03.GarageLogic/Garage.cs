using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageVehicleDetails> m_Garage = new Dictionary<string, GarageVehicleDetails>();

        public Dictionary<string, GarageVehicleDetails> GarageDictionary
        {
            get
            {
                return m_Garage;
            }

            set
            {
                m_Garage = value;
            }
        }

        public void AddNewVehicleToGarage(Vehicle i_NewVehicleToAdd, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            GarageVehicleDetails vehicleToAdd = new GarageVehicleDetails(i_NewVehicleToAdd, i_OwnerName, i_OwnerPhoneNumber);

            m_Garage.Add(i_NewVehicleToAdd.LicensePlate, vehicleToAdd);
        }
        
        public GarageVehicleDetails GetVehicleInGarage(string i_keyToFind)
        {
            GarageVehicleDetails VehicleDetails = null;

            foreach (KeyValuePair<string, GarageVehicleDetails> currentVehicleDetails in m_Garage)
            {
                if (currentVehicleDetails.Key == i_keyToFind)
                {
                    VehicleDetails = currentVehicleDetails.Value;
                    break;
                }
            }

            if (VehicleDetails == null)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Error! vehicle with licens plate {0} doesn't exists in garage", i_keyToFind));
                throw argumentException;
            }

            return VehicleDetails;
        }

        public List<string> GetLicensPlateList(int i_StatusChoice)
        {
            List<string> licensPlateList = new List<string>();

            foreach (KeyValuePair<string, GarageVehicleDetails> currentVehicleDetails in m_Garage)
            {
                if (i_StatusChoice == 4 || currentVehicleDetails.Value.VehicleStatus == (GarageVehicleDetails.eVehicleStatus)i_StatusChoice)
                {
                    licensPlateList.Add(currentVehicleDetails.Key);
                }
            }

            return licensPlateList;
        }

        public void ChangeVehicleStatus(string i_LicensPlate, GarageVehicleDetails.eVehicleStatus i_NewStatus)
        {
            if (m_Garage.ContainsKey(i_LicensPlate))
            {
                m_Garage[i_LicensPlate].VehicleStatus = i_NewStatus;
            }
            else
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Error! vehicle with licens plate {0} doesn't exists in garage", i_LicensPlate));
                throw argumentException;
            }
        }

        public void InflateAllWheelsToMax(string i_LicensPlate)
        {
            GarageVehicleDetails foundVehicle = GetVehicleInGarage(i_LicensPlate);

            foreach (Wheels currentWheel in foundVehicle.Vehicle.WheelsList)
            {
                currentWheel.InflateWheelToMax();
            }
        }

        public void FillVehicleTankFuel(string i_LicensPlate, float i_FuelToAdd, FuelSource.eFuelType i_FuelType)
        {
            GarageVehicleDetails foundVehicle = GetVehicleInGarage(i_LicensPlate);
            FuelSource vehicleFuelSource = foundVehicle.Vehicle.Engine as FuelSource;  
            
            if (vehicleFuelSource == null)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Error! vehicle with licens plate {0} is automatic", i_LicensPlate));
                throw argumentException;
            }
            else if (((FuelSource)(foundVehicle.Vehicle.Engine)).FuelType != i_FuelType)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Error! The fuel type you insert does not match the fuel type of the vehicle with licens plate {0} ", i_LicensPlate));
                throw argumentException;
            }
            else
            {
                vehicleFuelSource.FillTankFuel(i_FuelToAdd, i_FuelType);
            }
        }

        public void ChargeVehicleBattery(string i_LicensPlate, float i_MinutesToAdd)
        {
            GarageVehicleDetails foundVehicle = GetVehicleInGarage(i_LicensPlate);
            ElectricSource vehicleFuelSource = foundVehicle.Vehicle.Engine as ElectricSource;

            if (vehicleFuelSource != null)
            {
                vehicleFuelSource.ChargeBattery(i_MinutesToAdd / 60f); 
            }
            else
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Error! vehicle with licens plate {0} is not automatic", i_LicensPlate));
                throw argumentException;
            }
        }
    }
}
