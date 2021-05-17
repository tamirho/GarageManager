using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleParts
{
    internal abstract class EnergyUnit
    {
        protected float m_MaxEnergyCapacity;
        protected float m_CurrentEnergyAmount;

        internal EnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount)
        {
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            CurrentEnergyAmount = i_CurrentEnergyAmount;
        }

        internal EnergyUnit(float i_MaxEnergyCapacity)
        {
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            CurrentEnergyAmount = MaxEnergyCapacity * 0.75f;
        }

        internal float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
            set
            {
                if (value < 0  || value < CurrentEnergyAmount)
                {
                    throw new ArgumentException("Invalid MaxEnergyCapacity");
                }

                m_MaxEnergyCapacity = value;
            }
        }

        internal float CurrentEnergyAmount
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

        internal float GetCurrentEnergyPercentage()
        {
            return 100f * (CurrentEnergyAmount / MaxEnergyCapacity);
        }

        public override string ToString()
        {
            return string.Format(
                @"Max energy capacity: {0}
Current energy amount: {1}",
                m_MaxEnergyCapacity,
                m_CurrentEnergyAmount);
        }
    }
}
