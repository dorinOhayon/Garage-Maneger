using System;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        public enum eEngineType
        {
            Fuel = 1,
            Electric
        }

        private float m_MaxEngineEnergy;
        private float m_CurrentEngineEnergy;

        public float MaxEngineEnergy
        {
            get
            {
                return m_MaxEngineEnergy;
            }

            set
            {
                m_MaxEngineEnergy = value;
            }
        }

        public float CurrentEngineEnergy
        {
            get
            {
                return m_CurrentEngineEnergy;
            }

            set
            {
                m_CurrentEngineEnergy = value;
            }
        }
    }
}
