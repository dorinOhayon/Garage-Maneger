using System;

namespace Ex03.GarageLogic
{
    public class FuelSource : Engine
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public void FillTankFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if ((CurrentEngineEnergy + i_FuelToAdd > MaxEngineEnergy || CurrentEngineEnergy + i_FuelToAdd < 0))
            {
                ValueOutOfRangeException exceptionOutOfRange = new ValueOutOfRangeException(0, MaxEngineEnergy);
                throw exceptionOutOfRange;
            }
            else if(m_FuelType != i_FuelType)
            {
                ArgumentException argumentException = new ArgumentException("Error! fuel type is incorrect");
                throw argumentException;
            }

            CurrentEngineEnergy += i_FuelToAdd;
        }
    }
}
