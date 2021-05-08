using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public class Bike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        internal Bike(
            string i_LicenseNumber,
            string i_ModelName,
            List<Wheel> i_Wheels,
            EnergyUnit i_EnergyUnit,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }

        public enum eLicenseType
        {
            A,
            AA,
            B1,
            BB
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                if(!Enum.IsDefined(typeof(eLicenseType), value))
                {
                    throw new ArgumentException("Error with eLicenseType conversion");
                }

                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("EngineVolume must be a positive integer");
                }
                
                m_EngineVolume = value;
            }
        }

    }
}
