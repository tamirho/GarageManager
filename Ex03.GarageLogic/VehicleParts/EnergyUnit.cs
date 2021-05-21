using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleParts
{
    public abstract class EnergyUnit
    {
        private float m_MaxEnergyCapacity;
        private float m_CurrentEnergyAmount;

        internal EnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount)
        {
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            CurrentEnergyAmount = i_CurrentEnergyAmount;
        }

        internal EnergyUnit(float i_MaxEnergyCapacity)
        {
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            CurrentEnergyAmount = 0;
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
            internal set
            {
                if (value < 0  || value < CurrentEnergyAmount)
                {
                    throw new ArgumentException("Invalid MaxEnergyCapacity");
                }

                m_MaxEnergyCapacity = value;
            }
        }

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
            set
            {
                if (value > MaxEnergyCapacity || value < 0)
                {
                    throw new ValueOutOfRangeException("Invalid CurrentEnergyAmount ", value, 0, MaxEnergyCapacity);
                }

                m_CurrentEnergyAmount = value;
            }
        }

        public float GetCurrentEnergyPercentage()
        {
            return 100f * (CurrentEnergyAmount / MaxEnergyCapacity);
        }

        public override string ToString()
        {
            return string.Format(
                @"Max energy capacity: {0}
Current energy amount: {1}
Current energy percentage: {2}",
                m_MaxEnergyCapacity,
                m_CurrentEnergyAmount,
                GetCurrentEnergyPercentage());
        }
    }
}
