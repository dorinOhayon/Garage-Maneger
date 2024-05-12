using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManagement
    {
        private readonly Garage r_Garage = new Garage();

        public Garage Garage
        {
            get
            {
                return r_Garage;
            }
        }

        public void RunGarage()
        {
            int userInput;
            bool isExit = false;

            while (!isExit)
            {
                try
                {
                    printGarageMenue();
                    userInput = UserInput.GetUserMenueInput();
                    switch (userInput)
                    {
                        case 1:
                            {
                                insertVehicleToGarage();
                                break;
                            }
                        case 2:
                            {
                                displayVehicleLicensePlateList();
                                break;
                            }
                        case 3:
                            {
                                changeVehicleStatus();
                                break;
                            }
                        case 4:
                            {
                                inflateAllWheelsToMax();
                                break;
                            }
                        case 5:
                            {
                                fillVehicleTankFuel();                        
                                break;
                            }
                        case 6:
                            {
                                chargeVehicleBattery();
                                break;
                            }
                        case 7:
                            {
                                displayFullVehicleData();
                                break;
                            }
                        case 8:
                            {
                                isExit = true; 
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid input! please choose again");
                                break;
                            }
                    }
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }

                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            }
        }

        private void printGarageMenue()
        {
            Console.WriteLine("Welcome to Garage! Please choose from the options below :");
            Console.WriteLine("1. Insert a new Vehicle to garage" + Environment.NewLine + "2. Display Vehicles licens plate list"
                              + Environment.NewLine + "3. Change Vehicle status" + Environment.NewLine + "4. Inflate Vehicle wheels to maximum"
                              + Environment.NewLine + "5. Fill vehicle tank fuel" + Environment.NewLine + "6. Charge vehicle battery"
                              + Environment.NewLine + "7. Display full Vehicle data" + Environment.NewLine + "8. Exit");
        }

        private void insertVehicleToGarage()
        {
            bool isVehicleExists = false;
            string licensePlate = null, modelName, wheelManufacturer, ownerName, ownerPhone;
            Vehicle newVehicle;

            licensePlate = UserInput.GetLicensePlate();
            if (r_Garage.GarageDictionary.ContainsKey(licensePlate))
            {
                isVehicleExists = true;
            }

            if (isVehicleExists)
            {
                Console.WriteLine("This vehicle is already in the grage, it's status changed to in repair");
                r_Garage.ChangeVehicleStatus(licensePlate, GarageVehicleDetails.eVehicleStatus.InRepair);
            }
            else
            {
                modelName = UserInput.GetVehicleModelName();
                wheelManufacturer = UserInput.GetWheelManufacturer();
                newVehicle = createNewVehicle(licensePlate, modelName, wheelManufacturer, out ownerName, out ownerPhone);
                r_Garage.AddNewVehicleToGarage(newVehicle, ownerName, ownerPhone);
            }
        }

        private Vehicle createNewVehicle(string i_LicensePlate, string i_ModelName, string i_WheelManufacturer, out string o_OwnerName, out string o_OwnerPhone)
        {
            Vehicle newVehicle;
            Vehicle.eVehicleTypes vehicleType;
            Engine.eEngineType vehicleEngineType;

            o_OwnerName = UserInput.GetOwnerName();
            o_OwnerPhone = UserInput.GetOwnerPhone();
            vehicleType = UserInput.GetVehicleType();
            if (vehicleType != Vehicle.eVehicleTypes.Truck)
            {
                vehicleEngineType = UserInput.GetEngineType();
            }
            else
            {
                vehicleEngineType = Engine.eEngineType.Fuel;
            }

            newVehicle = VehicleProducer.CreateVehicle(vehicleType, i_ModelName, i_LicensePlate, vehicleEngineType, i_WheelManufacturer);
            newVehicle.InitEngineSource();
            insertVehicleDetails(newVehicle);

            return newVehicle;
        }

        private void insertVehicleDetails(Vehicle i_Vehicle)
        {
            if (i_Vehicle is Car)
            {
                Car newCar;
                Car.eColor carcColor;
                int amountOfDoors;

                newCar = i_Vehicle as Car;
                carcColor = UserInput.GetColor();
                newCar.Color = carcColor;
                amountOfDoors = UserInput.GetAmountOfDoors();
                newCar.AmountOfDoors = amountOfDoors;         
            }
            else if (i_Vehicle is Motorcycle)
            {
                Motorcycle newMotorcycle;
                string licenseType;
                int engineCapacity;

                newMotorcycle = i_Vehicle as Motorcycle;
                licenseType = UserInput.GetMotorcycleLicenseType();
                newMotorcycle.LicenseType = licenseType;
                engineCapacity = UserInput.GetEngineCapacity();
                newMotorcycle.EngeineCapcity = engineCapacity;
            }
            else if (i_Vehicle is Truck)
            {
                Truck newTruck;
                bool isCargoFrigerated;
                float cargoVolume;

                newTruck = i_Vehicle as Truck;
                isCargoFrigerated = UserInput.GetIfCargoreFrigerated();
                newTruck.IsCargoreFrigerated = isCargoFrigerated;
                cargoVolume = UserInput.GetCargoVolume();
                newTruck.CargoVolume = cargoVolume;
            }

            getCurrrentAirPressureOfWheels(i_Vehicle);
            getAmountOfEnergyToAdd(i_Vehicle);
        }

        private void getCurrrentAirPressureOfWheels(Vehicle i_Vehicle)
        {
            bool isValid = true;
            float airPressureToAdd;

            while (isValid)
            {
                airPressureToAdd = UserInput.GetAirPressureToWheels();
                try
                {
                    foreach (Wheels currentWheel in i_Vehicle.WheelsList)
                    {
                        currentWheel.InflateWheel(airPressureToAdd);
                    }

                    isValid = false;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }
        }

        private void getAmountOfEnergyToAdd(Vehicle i_Vehicle)
        {
            bool isValid = true;
            float amountOfEnergyToAdd;
            FuelSource.eFuelType fuelType;

            while (isValid)
            {
                amountOfEnergyToAdd = UserInput.GetAmountOfEnergyToAdd();
                try
                {
                    if (i_Vehicle.Engine is FuelSource)
                    {
                        FuelSource fuelTank = i_Vehicle.Engine as FuelSource;
                        fuelType = UserInput.GetFuelType();
                        fuelTank.FillTankFuel(amountOfEnergyToAdd, fuelType);
                    }
                    else
                    {
                        ElectricSource electricSource = i_Vehicle.Engine as ElectricSource;
                        electricSource.ChargeBattery(amountOfEnergyToAdd);
                    }

                    isValid = false;
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }

            i_Vehicle.UpdateEnergyPercent();
        }

        private void displayVehicleLicensePlateList()
        {
            List<string> licensePlateList;
            string stringUserInput;
            int userInput;

            Console.WriteLine("Choose from the options :" + Environment.NewLine + "1. By status in repair " + Environment.NewLine + "2. By status fixed" + Environment.NewLine +
                              "3. By status paid " + Environment.NewLine + "4. Full license plate list");
            stringUserInput = Console.ReadLine();
            if (!int.TryParse(stringUserInput, out userInput))
            {
                FormatException formatException = new FormatException("Error! Invalid input");
                throw formatException;
            }
            
            licensePlateList = r_Garage.GetLicensPlateList(userInput);
            if (licensePlateList.Count == 0) 
            {
                Console.WriteLine("There are no vehicles in the garage that match your choice");
            }
            else
            {
                Console.WriteLine("The licens plate list according to your choice : "); 
                foreach (string currentLicensePlate in licensePlateList)
                {
                    Console.WriteLine(currentLicensePlate);
                }
            }
        }

        private void changeVehicleStatus()
        {
            GarageVehicleDetails.eVehicleStatus statuseToUpdate;
            string licensePlate;

            licensePlate = UserInput.GetLicensePlate();
            statuseToUpdate = UserInput.GetStatus();
            r_Garage.ChangeVehicleStatus(licensePlate, statuseToUpdate);
        }

        private void inflateAllWheelsToMax()
        {
            string licensePlate;

            licensePlate = UserInput.GetLicensePlate();
            r_Garage.InflateAllWheelsToMax(licensePlate);
        }

        private void fillVehicleTankFuel()
        {
            float fuelToAdd;
            FuelSource.eFuelType fuelType;
            string licensePlate;

            licensePlate = UserInput.GetLicensePlate();
            fuelToAdd = UserInput.GetAmountOfEnergyToAdd();
            fuelType = UserInput.GetFuelType();
            r_Garage.FillVehicleTankFuel(licensePlate, fuelToAdd, fuelType);
        }

        private void chargeVehicleBattery()
        {
            float hoursToAdd;
            string licensePlate;

            licensePlate = UserInput.GetLicensePlate();
            hoursToAdd = UserInput.GetAmountOfEnergyToAdd();
            r_Garage.ChargeVehicleBattery(licensePlate, hoursToAdd);
        }

        private void displayFullVehicleData()
        {
            string licensePlate;
            GarageVehicleDetails vehicleDetails = null;

            licensePlate = UserInput.GetLicensePlate();
            vehicleDetails =  Garage.GetVehicleInGarage(licensePlate); 
            Console.WriteLine("Vehicle details are : ");
            Console.WriteLine("License plate : {0}" + Environment.NewLine + "Model name : {1}" + Environment.NewLine +
                              "Owner name : {2} " + Environment.NewLine + "Owner phone number : {3}" + Environment.NewLine +
                              "Vehicle status : {4}" + Environment.NewLine + "Wheels manufacturer name : {5}" + Environment.NewLine +
                              "Wheels max air pressure : {6}", licensePlate, vehicleDetails.Vehicle.ModelName , vehicleDetails.OwnerName, 
                              vehicleDetails.OwnerPhoneNumber, vehicleDetails.VehicleStatus, vehicleDetails.Vehicle.WheelsList[0].ManufacturerName,
                              vehicleDetails.Vehicle.WheelsList[0].MaxAirPressure);
            printVehicleDetailsByType(vehicleDetails.Vehicle);
        }

        private void printVehicleDetailsByType(Vehicle i_vehicle)
        {
            bool isElectric = true;

            if (i_vehicle.Engine is FuelSource)
            {
                isElectric = false;
            }
            else
            {
                Console.WriteLine("Engine type : electric");
            }

            if (i_vehicle is Car)
            {
                Car car;

                car = i_vehicle as Car;
                printCarDetails(car, isElectric);               
            }
            else if (i_vehicle is Motorcycle)
            {
                Motorcycle motorcycle;

                motorcycle = i_vehicle as Motorcycle;
                printMotorcycleDetails(motorcycle, isElectric);
            }
            else if (i_vehicle is Truck)
            {
                Truck truck;

                truck = i_vehicle as Truck;
                printTruckDetails(truck, isElectric);
            }
        }

        private void printCarDetails(Car i_Car, bool i_IsElectric)
        {
            Console.WriteLine("Vehicle type : car" + Environment.NewLine + "car's color : {0}" + Environment.NewLine +
                              "Amount of doors : {1}", i_Car.Color, i_Car.AmountOfDoors);
            if (!i_IsElectric)
            {
                Console.WriteLine("Engine type : fuel" + Environment.NewLine + "Fuel type : {0}", ((FuelSource)i_Car.Engine).FuelType);
            }
        }

        private void printMotorcycleDetails(Motorcycle i_Motorcycle, bool i_IsElectric)
        {
            Console.WriteLine("License type : {0}" + Environment.NewLine + "Engeine capcity : {1}", i_Motorcycle.LicenseType, i_Motorcycle.EngeineCapcity);
            if (!i_IsElectric)
            {
                Console.WriteLine("Engine type : fuel" + Environment.NewLine + "Fuel type : {0}", ((FuelSource)i_Motorcycle.Engine).FuelType);
            }
        }

        private void printTruckDetails(Truck i_Truck, bool i_IsElectric)
        {
            if (i_Truck.IsCargoreFrigerated)
            {
                Console.WriteLine("Truck cargore is frigerated");
            }
            else
            {
                Console.WriteLine("Truck cargore is not frigerated");
            }

            Console.WriteLine("Cargo volume : {0}", i_Truck.CargoVolume);
            Console.WriteLine("Engine type : fuel" + Environment.NewLine + "Fuel type : {0}", FuelSource.eFuelType.Soler);           
        }
    }
}
