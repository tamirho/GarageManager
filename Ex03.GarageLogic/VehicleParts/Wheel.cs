using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleParts
{
    internal class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        public void AddAirPressure(float i_AirPressure)
        {
            CurrentAirPressure = m_CurrentAirPressure + i_AirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                
                m_ManufacturerName = value;
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
                if (value < 0 || value > m_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException("Invalid CurrentAirPressure ", value, 0, m_MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxAirPressure must be a positive integer");
                }

                m_MaxAirPressure = value;
            }
        }
    }
}

