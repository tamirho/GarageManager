using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.VehicleParts
{
    class Wheels
    {
        private List<Wheel> m_WheelList;

        public Wheels(string i_ManufacturerName, int i_WheelsNum, float i_MaxAirPressure)
        {
            m_WheelList = new List<Wheel>();
            for (int i = 0; i < i_WheelsNum; i++)
            {
                m_WheelList.Add(new Wheel(i_ManufacturerName, i_MaxAirPressure * 0.75f, i_MaxAirPressure));
            }
        }

        public int WheelsNum
        {
            get
            {
                return m_WheelList.Count;
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return m_WheelList;
            }
        }
    }
}
