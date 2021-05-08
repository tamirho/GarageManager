namespace Ex03.GarageLogic.VehicleParts
{
    internal class ElectricEnergyUnit : EnergyUnit
    {
        public ElectricEnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount)
            : base(i_MaxEnergyCapacity, i_CurrentEnergyAmount)
        {
        }

        public ElectricEnergyUnit(float i_MaxEnergyCapacity)
            : base(i_MaxEnergyCapacity)
        {
        }

        internal void AddDrivingHours(float i_HoursToCharge)
        {
            CurrentEnergyAmount += i_HoursToCharge;
        }
    }
}
