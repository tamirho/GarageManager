using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Garage.Garage r_Garage;

        public GarageManager()
        {
            r_Garage = new Garage.Garage();
        }

        public Vehicle CreateVehicle(VehicleCreator.VehicleCreator.eVehiclesType i_Type)
        {
            return VehicleCreator.VehicleCreator.CreateVehicle(i_Type);
        }

        public void InsertVehicleToGarage(string i_OwnerName, string i_OwnersPhoneNumber, Vehicle i_Vehicle)
        {
            r_Garage.InsertNewVehicle(i_OwnerName, i_OwnersPhoneNumber, i_Vehicle);
        }

        public List<string> GetLicenseListOfExistingVehicle()
        {
            return r_Garage.GetLicenseListOfExistingVehicle();
        }

        public List<string> GetLicenseListOfExistingVehicle(GarageReport.eVehicleGarageStatus i_Status)
        {
            return r_Garage.GetLicenseListOfExistingVehicle(i_Status);
        }

        public void ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageReport.eVehicleGarageStatus i_Status)
        {
            r_Garage.ChangeVehicleStatusByLicenseNumber(i_LicenseNumber, i_Status);
        }

        public void InflateVehicleWheelsPressureToMaxByLicenseNumber(string i_LicenseNumber)
        {
            r_Garage.InflateVehicleWheelsPressureToMaxByLicenseNumber(i_LicenseNumber);
        }

        public void RefuelVehicleByLicenseNumber(string i_LicenseNumber, FuelEnergyUnit.eFuelType i_FuelType, float i_FuelLiters)
        {
            r_Garage.RefuelVehicleByLicenseNumber(i_LicenseNumber, i_FuelType, i_FuelLiters);
        }

        public void ChargeElectricVehicleByLicenseNumber(string i_LicenseNumber, float i_HoursToCharge)
        {
            r_Garage.ChargeElectricVehicleByLicenseNumber(i_LicenseNumber, i_HoursToCharge);
        }

        public bool CheckIfExistingVehicleReport(string i_LicenseNumber)
        {
            return r_Garage.CheckIfExistingVehicleReport(i_LicenseNumber);
        }

        public Dictionary<string, GarageReport> GarageReports
        {
            get
            {
                return r_Garage.GarageReports;
            }
        }
    }
}
