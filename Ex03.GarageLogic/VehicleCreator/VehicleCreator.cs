using System;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.VehicleCreator
{
    public class VehicleCreator
    {
        public enum eVehiclesType
        {
            NormalBike = 1,
            ElectricBike,
            NormalCar,
            ElectricCar,
            Truck
        }

        public static Vehicle CreateVehicle(eVehiclesType i_Type)
        {
            Vehicle theVehicle;
            try
            {
                switch(i_Type)
                {
                    case eVehiclesType.NormalBike:
                        theVehicle = new Bike();
                        theVehicle.Wheels = new Wheels(k_BikeWheelsNumber, k_BikeWheelMaxAirCapacity);
                        theVehicle.EnergyUnit = new FuelEnergyUnit(k_NormalBikeMaxFuelCapacity, k_NormalBikeFuelType);
                        break;
                    case eVehiclesType.ElectricBike:
                        theVehicle = new Bike();
                        theVehicle.Wheels = new Wheels(k_BikeWheelsNumber, k_BikeWheelMaxAirCapacity);
                        theVehicle.EnergyUnit = new ElectricEnergyUnit(k_ElectricBikeMaxBatteryCapacity);
                        break;
                    case eVehiclesType.NormalCar:
                        theVehicle = new Car();
                        theVehicle.Wheels = new Wheels(k_CarWheelsNumber, k_CarWheelMaxAirCapacity);
                        theVehicle.EnergyUnit = new FuelEnergyUnit(k_NormalCarMaxFuelCapacity, k_NormalCarFuelType);
                        break;
                    case eVehiclesType.ElectricCar:
                        theVehicle = new Car();
                        theVehicle.Wheels = new Wheels(k_CarWheelsNumber, k_CarWheelMaxAirCapacity);
                        theVehicle.EnergyUnit = new ElectricEnergyUnit(k_ElectricCarMaxBatteryCapacity);
                        break;
                    case eVehiclesType.Truck:
                        theVehicle = new Truck();
                        theVehicle.Wheels = new Wheels(k_TruckWheelsNumber, k_TruckWheelMaxAirCapacity);
                        theVehicle.EnergyUnit = new FuelEnergyUnit(k_TruckMaxFuelCapacity, k_TruckFuelType);
                        break;
                    default:
                        throw new FormatException("No such vehicle type");
                }
            }
            catch(Exception exception)
            {
                throw new VehicleCreatorException(exception);
            }

            return theVehicle;
        }

        private const int k_BikeWheelsNumber = 2;
        private const int k_CarWheelsNumber = 4;
        private const int k_TruckWheelsNumber = 16;

        private const float k_BikeWheelMaxAirCapacity = 30f;
        private const float k_CarWheelMaxAirCapacity = 32f;
        private const float k_TruckWheelMaxAirCapacity = 26f;

        private const FuelEnergyUnit.eFuelType k_NormalBikeFuelType = FuelEnergyUnit.eFuelType.Octan98;
        private const FuelEnergyUnit.eFuelType k_NormalCarFuelType = FuelEnergyUnit.eFuelType.Octan95;
        private const FuelEnergyUnit.eFuelType k_TruckFuelType = FuelEnergyUnit.eFuelType.Soler;

        private const float k_NormalBikeMaxFuelCapacity = 6f;
        private const float k_NormalCarMaxFuelCapacity = 45f;
        private const float k_TruckMaxFuelCapacity = 120f;
        private const float k_ElectricBikeMaxBatteryCapacity = 1.8f;
        private const float k_ElectricCarMaxBatteryCapacity = 3.2f;
    }
}
