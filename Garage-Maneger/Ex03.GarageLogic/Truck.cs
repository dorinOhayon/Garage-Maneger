using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCargoreFrigerated;
        private float m_CargoVolume;
        private const int k_AmountOfWheels = 16;
        private const float k_TruckMaxFuel = 120;

        public Truck(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType, string i_ManufacturerName)
            : base(i_ModelName, i_LicensePlate, i_EngineType)
        {
            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                this.WheelsList.Add(new Wheels(i_ManufacturerName, (float)Wheels.eMaxAirPressure.Truck));
            }
        }

        public bool IsCargoreFrigerated
        {
            get
            {
                return m_IsCargoreFrigerated;
            }

            set
            {
                m_IsCargoreFrigerated = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }

        public override void InitEngineSource()
        {
            Engine.MaxEngineEnergy = k_TruckMaxFuel;
            ((FuelSource)Engine).FuelType = FuelSource.eFuelType.Soler;
        }
    }
}
