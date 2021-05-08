using System;

namespace Ex03.GarageLogic.VehicleParts
{
    internal class FuelEnergyUnit : EnergyUnit
    {
        private eFuelType m_FuelType;

        public FuelEnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity, i_CurrentEnergyAmount)
        {
            FuelType = i_FuelType;
        }

        public FuelEnergyUnit(float i_MaxEnergyCapacity, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity)
        {
            FuelType = i_FuelType;
        }

        internal eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eFuelType), value))
                {
                    throw new ArgumentException("Error with FuelType enum convert ");
                }

                m_FuelType = value;
            }
        }

        internal void AddFuel(float i_FuelLiters, eFuelType i_FuelType)
        {
            if(m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Incorrect fuel type ");
            }

            CurrentEnergyAmount += i_FuelLiters;
        }
    }
}
