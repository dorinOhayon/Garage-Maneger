using System;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public enum eMaxAirPressure
        {
            Car = 29,
            Truck = 24,
            Motorcycle = 31
        }

        public Wheels(string i_ManufacturerName, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public void InflateWheel(float i_AirPressureToAdd)
        {
            if (CurrentAirPressure + i_AirPressureToAdd > MaxAirPressure || CurrentAirPressure + i_AirPressureToAdd < 0)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(0, m_MaxAirPressure);
                throw valueOutOfRangeException;
            }

            CurrentAirPressure += i_AirPressureToAdd;
        }

        public void InflateWheelToMax()
        {
            float airPressuerToAdd;

            airPressuerToAdd = MaxAirPressure - CurrentAirPressure;
            InflateWheel(airPressuerToAdd);
        }
    }
}
