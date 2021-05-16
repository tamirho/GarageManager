using System;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.VehicleCreator
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(
            eVehiclesType i_Type,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelsManufacturerName,
            object[] i_VehicleSpecialParams)
        {
            Vehicle theVehicle;
            try
            {
                switch(i_Type)
                {
                    case eVehiclesType.NormalBike:
                        theVehicle = new Bike(
                            i_LicenseNumber,
                            i_ModelName,
                            new Wheels(i_WheelsManufacturerName, k_BikeWheelsNumber, k_BikeWheelMaxAirCapacity),
                            new FuelEnergyUnit(k_NormalBikeMaxFuelCapacity, k_NormalBikeFuelType),
                            i_VehicleSpecialParams);
                        break;
                    case eVehiclesType.ElectricBike:
                        theVehicle = new Bike(
                            i_LicenseNumber,
                            i_ModelName,
                            new Wheels(i_WheelsManufacturerName, k_BikeWheelsNumber, k_BikeWheelMaxAirCapacity),
                            new ElectricEnergyUnit(k_ElectricBikeMaxBatteryCapacity),
                            i_VehicleSpecialParams);
                        break;
                    case eVehiclesType.NormalCar:
                        theVehicle = new Car(
                            i_LicenseNumber,
                            i_ModelName,
                            new Wheels(i_WheelsManufacturerName, k_CarWheelsNumber, k_CarWheelMaxAirCapacity),
                            new FuelEnergyUnit(k_NormalCarMaxFuelCapacity, k_NormalCarFuelType),
                            i_VehicleSpecialParams);
                        break;
                    case eVehiclesType.ElectricCar:
                        theVehicle = new Car(
                            i_LicenseNumber,
                            i_ModelName,
                            new Wheels(i_WheelsManufacturerName, k_CarWheelsNumber, k_CarWheelMaxAirCapacity),
                            new ElectricEnergyUnit(k_ElectricCarMaxBatteryCapacity),
                            i_VehicleSpecialParams);
                        break;
                    case eVehiclesType.Truck:
                        theVehicle = new Truck(
                            i_LicenseNumber,
                            i_ModelName,
                            new Wheels(i_WheelsManufacturerName, k_TruckWheelsNumber, k_TruckWheelMaxAirCapacity),
                            new FuelEnergyUnit(k_TruckMaxFuelCapacity, k_TruckFuelType),
                            i_VehicleSpecialParams);
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

        private const eFuelType k_NormalBikeFuelType = eFuelType.Octan98;
        private const eFuelType k_NormalCarFuelType = eFuelType.Octan95;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        private const float k_NormalBikeMaxFuelCapacity = 6f;
        private const float k_NormalCarMaxFuelCapacity = 45f;
        private const float k_TruckMaxFuelCapacity = 120f;
        private const float k_ElectricBikeMaxBatteryCapacity = 1.8f;
        private const float k_ElectricCarMaxBatteryCapacity = 3.2f;
    }
}
