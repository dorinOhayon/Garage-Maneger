using System;

namespace Ex03.GarageLogic
{
    public class ElectricSource : Engine
    {
        public void ChargeBattery(float i_HoursToAdd)
        {
            if (CurrentEngineEnergy + i_HoursToAdd > MaxEngineEnergy || CurrentEngineEnergy + i_HoursToAdd < 0)
            {
                ValueOutOfRangeException exceptionOutOfRange = new ValueOutOfRangeException(0, MaxEngineEnergy);
                throw exceptionOutOfRange;
            }

            CurrentEngineEnergy += i_HoursToAdd;
        }
    }
}
