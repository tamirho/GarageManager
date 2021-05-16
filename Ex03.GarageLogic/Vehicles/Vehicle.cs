using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_LicenseNumber;
        private string m_ModelName;
        private Wheels m_Wheels;
        private EnergyUnit m_EnergyUnit;

        internal Vehicle(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels, EnergyUnit i_EnergyUnit)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            Wheels = i_Wheels;
            EnergyUnit = i_EnergyUnit;
        }

        internal Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
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

        internal Wheels Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
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

        public override string ToString()
        {
            return string.Format(
                @"License number: {0}
Model name: {1}
{2}
{3}",
                m_LicenseNumber,
                m_ModelName,
                m_Wheels,
                m_EnergyUnit);
        }

    }
}
