using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleParts
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        internal Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = 0;
        }

        internal Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = 0;
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

        internal float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            private set
            {
                if (value < 0 || value < MaxAirPressure)
                {
                    throw new ArgumentException("MaxAirPressure must be a positive integer");
                }

                m_MaxAirPressure = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacturer name: {0} | Current air pressure: {1}",
                m_ManufacturerName,
                m_CurrentAirPressure);
        }
    }
}
