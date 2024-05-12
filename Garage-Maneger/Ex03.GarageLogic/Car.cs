using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            red = 1,
            white,
            green,
            blue
        }

        private eColor m_Color;
        private int m_AmountOfDoors;
        private const int k_AmountOfWheels = 4;
        private const float k_CarMaxFuel = 38;
        private const float k_CarMaxBattery = 3.3f;

        public Car(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType, string i_ManufacturerName)
                  : base(i_ModelName, i_LicensePlate, i_EngineType)
        {
            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                this.WheelsList.Add(new Wheels(i_ManufacturerName, (float)Wheels.eMaxAirPressure.Car));
            }
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public int AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }

            set
            {
                m_AmountOfDoors = value;
            }
        }

        public override void InitEngineSource()
        {
            if (Engine is FuelSource)
            {
                Engine.MaxEngineEnergy = k_CarMaxFuel;
                ((FuelSource)Engine).FuelType = FuelSource.eFuelType.Octan95;
            }
            else
            {
                Engine.MaxEngineEnergy = k_CarMaxBattery;
            }
        }
    }
}
