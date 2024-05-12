using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInput
    {
        public static int GetUserMenueInput()
        {
            string stringUserInput = Console.ReadLine();
            int userInput;

            if (!int.TryParse(stringUserInput, out userInput))
            {
                FormatException formatException = new FormatException("Error! Invalid input");
                throw formatException;
            }

            return userInput;
        }

        public static string GetLicensePlate()
        {
            string userInput;

            Console.WriteLine("Please enter vehicle license plate: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static string GetVehicleModelName()
        {
            string userInput;

            Console.WriteLine("Please insert vehicle model name: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static string GetWheelManufacturer()
        {
            string userInput;

            Console.WriteLine("Please enter wheel manufacturer name: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static string GetOwnerName()
        {
            string userInput;

            Console.WriteLine("Please enter owner name: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static string GetOwnerPhone()
        {
            string userInput;

            Console.WriteLine("Please enter owner phone number: ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static Vehicle.eVehicleTypes GetVehicleType()
        {
            string stringUserInput;
            Vehicle.eVehicleTypes vehicleType;
            int userInput;
            bool isValid = true;

            Console.WriteLine("Please enter type of Vehicle :" + Environment.NewLine + "1. Car" + Environment.NewLine + "2. Motorcycle" + Environment.NewLine + "3. Truck");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInput))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInput = int.Parse(stringUserInput);
            vehicleType = (Vehicle.eVehicleTypes)userInput;

            return vehicleType;
        }

        public static Engine.eEngineType GetEngineType()
        {
            string stringUserInput;
            Engine.eEngineType engineType;
            int userInput;
            bool isValid = true;

            Console.WriteLine("please enter engine type: " + Environment.NewLine + "1. Fuel " + Environment.NewLine + "2. Electric ");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInput))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInput = int.Parse(stringUserInput);
            engineType = (Engine.eEngineType)userInput;

            return engineType;
        }

        public static Car.eColor GetColor()
        {
            string stringUserInput;
            Car.eColor carColor;
            int userInput;
            bool isValid = true;

            Console.WriteLine("please choose car color: " + Environment.NewLine + "1. Red " + Environment.NewLine + "2. white " + Environment.NewLine + "3. Green " + Environment.NewLine + "4. Blue ");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInput))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInput = int.Parse(stringUserInput);
            carColor = (Car.eColor)userInput;

            return carColor;
        }

        public static int GetAmountOfDoors()
        {
            string stringUserInput;
            int amountOfDoors;
            bool isValid = true;

            Console.WriteLine("please choose amount of doors to car: " + Environment.NewLine + "1 / 2 / 3 / 4 ");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out amountOfDoors))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            amountOfDoors = int.Parse(stringUserInput);

            return amountOfDoors;
        }

        public static string GetMotorcycleLicenseType()
        {
            string userInput;

            Console.WriteLine("Please enter motorcycle license type: " + Environment.NewLine + "A / A1 / B1 / BB ");
            userInput = Console.ReadLine();

            return userInput;
        }

        public static int GetEngineCapacity()
        {
            string stringUserInput;
            int engineCapacity;
            bool isValid = true;

            Console.WriteLine("please enter engine capacity: ");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out engineCapacity))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            engineCapacity = int.Parse(stringUserInput);

            return engineCapacity;
        }

        public static bool GetIfCargoreFrigerated()
        {
            string stringUserInput;
            int userInputNumber;
            bool isCargoreFrigerated;
            bool isValid = true;

            Console.WriteLine("Please choose if the cargo is Frigerated: " + Environment.NewLine + "1. Yes" + Environment.NewLine + "2. No");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInputNumber))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInputNumber = int.Parse(stringUserInput);
            if (userInputNumber == 1)
            {
                isCargoreFrigerated = true;
            }
            else
            {
                isCargoreFrigerated = false;
            }

            return isCargoreFrigerated;
        }

        public static float GetCargoVolume()
        {
            string stringUserInput;
            float cargoVolume;
            bool isValid = true;

            Console.WriteLine("please enter cargo volume : ");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!float.TryParse(stringUserInput, out cargoVolume))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            cargoVolume = float.Parse(stringUserInput);
            
            return cargoVolume;
        }

        public static float GetAirPressureToWheels()
        {
            string stringUserInput;
            float airPressureToAdd;
            bool isValid = true;

            Console.WriteLine("Please enter air pressure to add to vehicle");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!float.TryParse(stringUserInput, out airPressureToAdd))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            airPressureToAdd = float.Parse(stringUserInput);

            return airPressureToAdd;
        }

        public static float GetAmountOfEnergyToAdd() 
        {
            string stringUserInput;
            float amountOfEnergyToAdd;
            bool isValid = true;

            Console.WriteLine("Please enter amount of energy to add to vehicle");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!float.TryParse(stringUserInput, out amountOfEnergyToAdd))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            amountOfEnergyToAdd = float.Parse(stringUserInput);

            return amountOfEnergyToAdd;
        }

        public static FuelSource.eFuelType GetFuelType()
        {
            string stringUserInput;
            FuelSource.eFuelType fuelType;
            int userInput;
            bool isValid = true;

            Console.WriteLine("Please enter fuel type" + Environment.NewLine + "1. soler" + Environment.NewLine + "2. Octan95" + Environment.NewLine + "3. Octan96" + Environment.NewLine + "4. Octan98");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInput))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInput = int.Parse(stringUserInput);           
            fuelType = (FuelSource.eFuelType)userInput;

            return fuelType;
        }

        public static GarageVehicleDetails.eVehicleStatus GetStatus()
        {
            string stringUserInput;
            GarageVehicleDetails.eVehicleStatus status;
            int userInput;
            bool isValid = true;

            Console.WriteLine("please choose status :" + Environment.NewLine + "1. In repair" + Environment.NewLine + "2. Fixed" + Environment.NewLine + "3. Paid");
            stringUserInput = Console.ReadLine();
            while (isValid)
            {
                try
                {
                    if (!int.TryParse(stringUserInput, out userInput))
                    {
                        FormatException formatException = new FormatException("Error! Invalid input, please try again");
                        throw formatException;
                    }

                    isValid = false;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    stringUserInput = Console.ReadLine();
                }
            }

            userInput = int.Parse(stringUserInput);
            status = (GarageVehicleDetails.eVehicleStatus)userInput;

            return status;
        }
    }
}
