﻿using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleParts
{
    internal class Wheels
    {
        private List<Wheel> m_WheelsList;

        internal Wheels(string i_ManufacturerName, int i_WheelsNum, float i_MaxAirPressure)
        {
            m_WheelsList = new List<Wheel>();
            for(int i = 0; i < i_WheelsNum; i++)
            {
                m_WheelsList.Add(new Wheel(i_ManufacturerName, i_MaxAirPressure * 0.75f, i_MaxAirPressure));
            }
        }

        internal int WheelsNum
        {
            get
            {
                return m_WheelsList.Count;
            }
        }

        internal List<Wheel> WheelsList
        {
            get
            {
                return m_WheelsList;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelStringBuilder = new StringBuilder();
            wheelStringBuilder.AppendFormat(
                @"Wheels:
Number of wheels: {0}",
                WheelsNum);
            foreach(Wheel wheel in m_WheelsList)
            {
                wheelStringBuilder.AppendFormat(@"
{0}",wheel);
            }

            return wheelStringBuilder.ToString();
        }
    }
}
