using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private string m_LicenseType;
        private int m_EngeineCapcity;
        private const int k_AmountOfWheels = 2;
        private const float k_MororcycleMaxFuel = 6.2f;
        private const float k_MororcycleMaxBattery = 2.5f;

        public Motorcycle(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType, string i_ManufacturerName)
            : base(i_ModelName, i_LicensePlate, i_EngineType)
        {
            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                this.WheelsList.Add(new Wheels(i_ManufacturerName, (float)Wheels.eMaxAirPressure.Motorcycle));
            }
        }

        public string LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngeineCapcity
        {
            get
            {
                return m_EngeineCapcity;
            }

            set
            {
                m_EngeineCapcity = value;
            }
        }

        public override void InitEngineSource()
        {
            if (Engine is FuelSource)
            {
                Engine.MaxEngineEnergy = k_MororcycleMaxFuel;
                ((FuelSource)Engine).FuelType = FuelSource.eFuelType.Octan98;
            }
            else
            {
                Engine.MaxEngineEnergy = k_MororcycleMaxBattery;
            }
        }
    }
}
