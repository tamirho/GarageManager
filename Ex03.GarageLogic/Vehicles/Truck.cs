using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private eHazardousMaterials m_IsDrivesHazardousMaterials;
        private float m_MaxCapacityWeight;
        
        internal Truck(
            string i_LicenseNumber,
            string i_ModelName,
            Wheels i_Wheels,
            EnergyUnit i_EnergyUnit,
            eHazardousMaterials i_IsDrivesHazardousMaterials,
            float i_MaxCapacityWeight)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            IsDrivesHazardousMaterials = i_IsDrivesHazardousMaterials;
            MaxCapacityWeight = i_MaxCapacityWeight;
        }

        internal Truck(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels, EnergyUnit i_EnergyUnit, object[] i_VehicleSpecialParams)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            IsDrivesHazardousMaterials = (eHazardousMaterials)i_VehicleSpecialParams[(int)eTruckSpecialParams.IsDrivesHazardousMaterials];
            MaxCapacityWeight = (float)i_VehicleSpecialParams[(int)eTruckSpecialParams.MaxCapacityWeight];
        }

        public enum eHazardousMaterials
        {
            ContainsHazardousMaterials = 1,
            NotContainsHazardousMaterials
        }

        public enum eTruckSpecialParams
        {
            IsDrivesHazardousMaterials = 0,
            MaxCapacityWeight
        }

        public eHazardousMaterials IsDrivesHazardousMaterials
        {
            get
            {
                return m_IsDrivesHazardousMaterials;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eHazardousMaterials), value))
                {
                    throw new ArgumentException("Error with eHazardousMaterials conversion");
                }

                m_IsDrivesHazardousMaterials = value;
            }
        }

        public float MaxCapacityWeight
        {
            get
            {
                return m_MaxCapacityWeight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxCapacityWeight must be a positive integer");
                }

                m_MaxCapacityWeight = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Truck:
{0}
Hazardous materials details: {1}
Max capacity weight: {2}",
                base.ToString(),
                m_IsDrivesHazardousMaterials,
                m_MaxCapacityWeight);
        }
    }
}
