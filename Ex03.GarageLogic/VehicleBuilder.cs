using System;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {

//        public Vehicle CreateVehicle(string i_LicenseNumber, eVehiclesTypes i_Type)
//        {
//            Vehicle theVehicle;

//            switch(i_Type)
//            {
//                case eVehiclesTypes.NormalBike:
//\                    break;
//                case eVehiclesTypes.ElectricBike:
//                    break;
//                case eVehiclesTypes.NormalCar:
//                    break;
//                case eVehiclesTypes.ElectricCar:
//                    break;
//                case eVehiclesTypes.Truck:
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(i_Type), i_Type, null);
//            };
//        }


        private const int k_BikeWheelsNumber = 2;
        private const int k_CarWheelsNumber = 4;
        private const int k_TruckWheelsNumber = 16;

        private const float k_BikeWheelMaxAirCapacity = 30;
        private const float k_CarWheelMaxAirCapacity = 32;
        private const float k_TruckWheelMaxAirCapacity = 26;

        private const eFuelType k_NormalBikeFuelType = eFuelType.Octan98;
        private const eFuelType k_NormalCarFuelType = eFuelType.Octan95;
        private const eFuelType k_TruckCarFuelType = eFuelType.Soler;

        private const float k_NormalBikeMaxFuelCapacity = 6;
        private const float k_NormalCarMaxFuelCapacity = 45;
        private const float k_TruckMaxFuelCapacity = 120;
        private const float k_ElectricBikeMaxBatteryCapacity = 1.8f;
        private const float k_ElectricCarMaxBatteryCapacity = 3.2f;
    }

    public enum eVehiclesTypes
    {
        NormalBike,
        ElectricBike,
        NormalCar,
        ElectricCar,
        Truck
    }


}
