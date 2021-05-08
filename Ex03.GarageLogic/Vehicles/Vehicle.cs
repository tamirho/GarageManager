using System.Collections.Generic;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_LicenseNumber;
        private string m_ModelName;
        private List<Wheel> m_WheelsList;
        private EnergyUnit m_EnergyUnit;

        internal Vehicle(string i_LicenseNumber, string i_ModelName, List<Wheel> i_Wheels, EnergyUnit i_EnergyUnit)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            WheelsList = i_Wheels;
            EnergyUnit = i_EnergyUnit;
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        internal List<Wheel> WheelsList
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

        internal EnergyUnit EnergyUnit
        {
            get
            {
                return m_EnergyUnit;
            }
            set
            {
                m_EnergyUnit = value;
            }
        }

        public float EnergyPercentageRemain
        {
            get
            {
                return m_EnergyUnit.GetCurrentEnergyPercentage();
            }
        }

    }
}
