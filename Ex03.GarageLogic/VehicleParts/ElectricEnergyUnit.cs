namespace Ex03.GarageLogic.VehicleParts
{
    internal class ElectricEnergyUnit : EnergyUnit
    {
        internal ElectricEnergyUnit(float i_MaxEnergyCapacity, float i_CurrentEnergyAmount)
            : base(i_MaxEnergyCapacity, i_CurrentEnergyAmount)
        {
        }

        internal ElectricEnergyUnit(float i_MaxEnergyCapacity)
            : base(i_MaxEnergyCapacity)
        {
        }

        internal void AddDrivingHours(float i_HoursToCharge)
        {
            CurrentEnergyAmount += i_HoursToCharge;
        }

        public override string ToString()
        {
            return string.Format(
                @"Electric Energy Unit:
{0}",
                base.ToString());
        }
    }
}
