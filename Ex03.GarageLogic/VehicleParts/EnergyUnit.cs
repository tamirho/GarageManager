using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleParts
{
    internal abstract class EnergyUnit
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
        }

        internal float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(
                        "MaxEnergyCapacity must be a positive number"));
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
                    throw new ValueOutOfRangeException("Invalid CurrentEnergyAmount ", CurrentEnergyAmount, 0, MaxEnergyCapacity);
                }

                m_CurrentEnergyAmount = value;
            }
        }

        internal float GetCurrentEnergyPercentage()
        {
            return 100f * (CurrentEnergyAmount / MaxEnergyCapacity);
        }
    }
}
