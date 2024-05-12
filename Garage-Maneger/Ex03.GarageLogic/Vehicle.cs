using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlate;
        private float m_EnergyPrecent;
        private List<Wheels> m_WheelsList;
        private Engine m_Engine;

        public enum eVehicleTypes
        {
            Car = 1,
            Motorcycle,
            Truck
        }

        public Vehicle(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            m_WheelsList = new List<Wheels>();
            if (i_EngineType == Engine.eEngineType.Fuel)
            {
                m_Engine = new FuelSource();
            }
            else
            {
                m_Engine = new ElectricSource();
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public float EnergyPrecent
        {
            get
            {
                return m_EnergyPrecent;
            }

            set
            {
                m_EnergyPrecent = value;
            }
        }

        public List<Wheels> WheelsList
        {
            get
            {
                return m_WheelsList;
            }

            set
            {
                m_WheelsList = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public void UpdateEnergyPercent()
        {
            EnergyPrecent = (Engine.CurrentEngineEnergy / Engine.MaxEngineEnergy) * 100;
        }

        public abstract void InitEngineSource();
    }
}
