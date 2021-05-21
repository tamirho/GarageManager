using System;

namespace Ex03.GarageLogic.VehicleParts
{
    public class FuelEnergyUnit : EnergyUnit
    {
        private eFuelType m_FuelType;

        internal FuelEnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity, i_CurrentEnergyAmount)
        {
            FuelType = i_FuelType;
        }

        internal FuelEnergyUnit(float i_MaxEnergyCapacity, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity)
        {
            FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Octan98 = 1,
            Octan96,
            Octan95,
            Soler
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            internal set
            {
                if (!Enum.IsDefined(typeof(eFuelType), value))
                {
                    throw new ArgumentException("Error with FuelType enum convert ");
                }

                m_FuelType = value;
            }
        }

        public void AddFuel(float i_FuelLiters, eFuelType i_FuelType)
        {
            if(m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Incorrect fuel type ");
            }

            CurrentEnergyAmount += i_FuelLiters;
        }

        public override string ToString()
        {
            return string.Format(
                @"Fuel Energy Unit:
{0}
Fuel type: {1}",
                base.ToString(),
                m_FuelType);
        }
    }
}
