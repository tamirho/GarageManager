﻿using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivesHazardousMaterials;
        private float m_MaxCapacityWeight;

        internal Truck(
            string i_LicenseNumber,
            string i_ModelName,
            List<Wheel> i_Wheels,
            EnergyUnit i_EnergyUnit,
            bool i_IsDrivesHazardousMaterials,
            float i_MaxCapacityWeight)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            IsDrivesHazardousMaterials = i_IsDrivesHazardousMaterials;
            MaxCapacityWeight = i_MaxCapacityWeight;
        }

        public bool IsDrivesHazardousMaterials
        {
            get
            {
                return m_IsDrivesHazardousMaterials;
            }
            set
            {
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
    }
}