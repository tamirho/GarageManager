
using System;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_LicenseNumber;
        private string m_ModelName;
        private Wheels m_Wheels;
        private EnergyUnit m_EnergyUnit;

        internal Vehicle() {}

        internal Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
        }

        internal Vehicle(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels, EnergyUnit i_EnergyUnit)
        {
            LicenseNumber = i_LicenseNumber;
            ModelName = i_ModelName;
            Wheels = i_Wheels;
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

        public Wheels Wheels
        {
            get
            {
                return m_Wheels;
            }
            internal set
            {
                m_Wheels = value;
            }
        }

        public EnergyUnit EnergyUnit
        {
            get
            {
                return m_EnergyUnit;
            }
            internal set
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

        public abstract Tuple<string, object, Type>[] GetSpecialParamsDescriptions();
        public abstract void SetSpecialParams(object[] i_SpecialParamsInputs);

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
