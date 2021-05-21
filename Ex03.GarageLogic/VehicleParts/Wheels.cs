using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleParts
{
    public class Wheels
    {
        private List<Wheel> m_WheelsList;

        internal Wheels(int i_WheelsNum, float i_MaxAirPressure)
        {
            m_WheelsList = new List<Wheel>();
            for(int i = 0; i < i_WheelsNum; i++)
            {
                m_WheelsList.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return m_WheelsList;
            }
        }

        public void SetWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void SetWheelsAirPressure(float i_AirPressure)
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelStringBuilder = new StringBuilder();
            wheelStringBuilder.AppendFormat(
                @"Wheels:
Number of wheels: {0}",
                m_WheelsList.Count);
            foreach(Wheel wheel in m_WheelsList)
            {
                wheelStringBuilder.AppendFormat(
                    @"
{0}",
                    wheel);
            }

            return wheelStringBuilder.ToString();
        }
    }
}
