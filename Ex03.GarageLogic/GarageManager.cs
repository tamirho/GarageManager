using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehicleCreator;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Garage.Garage m_Garage;

        public GarageManager()
        {
            m_Garage = new Garage.Garage();
        }



        public Vehicle CreateVehicle(
            eVehiclesType i_Type,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelsManufacturerName,
            object[] i_VehicleSpecialParams)
        {
            return VehicleCreator.VehicleCreator.CreateVehicle(
                 i_Type,
                 i_LicenseNumber,
                 i_ModelName,
                 i_WheelsManufacturerName,
                 i_VehicleSpecialParams);
        }

        public void CreateAndInsertNewVehicle(
            string i_OwnerName,
            string i_OwnersPhoneNumber,
            eVehiclesType i_Type,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelsManufacturerName,
            object[] i_VehicleSpecialParams)
        {
            Vehicle newVehicle = CreateVehicle(i_Type, i_LicenseNumber, i_ModelName, i_WheelsManufacturerName, i_VehicleSpecialParams);
            InsertVehicleToGarage(i_OwnerName, i_OwnersPhoneNumber, newVehicle);
        }

        public void InsertVehicleToGarage(string i_OwnerName, string i_OwnersPhoneNumber, Vehicle i_Vehicle)
        {
            m_Garage.InsertNewVehicle(i_OwnerName, i_OwnersPhoneNumber, i_Vehicle);
        }

        public List<string> GetLicenseListOfExistingVehicle()
        {
            return m_Garage.GetLicenseListOfExistingVehicle();
        }

        public List<string> GetLicenseListOfExistingVehicle(GarageReport.eVehicleGarageStatus i_Status)
        {
            return m_Garage.GetLicenseListOfExistingVehicle(i_Status);
        }

        public void ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageReport.eVehicleGarageStatus i_Status)
        {
            m_Garage.ChangeVehicleStatusByLicenseNumber(i_LicenseNumber, i_Status);
        }

        public void InflateVehicleWheelsPressureToMaxByLicenseNumber(string i_LicenseNumber)
        {
            m_Garage.InflateVehicleWheelsPressureToMaxByLicenseNumber(i_LicenseNumber);
        }

        public void RefuelVehicleByLicenseNumber(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLiters)
        {
            m_Garage.RefuelVehicleByLicenseNumber(i_LicenseNumber, i_FuelType, i_FuelLiters);
        }

        public void ChargeElectricVehicleByLicenseNumber(string i_LicenseNumber, float i_HoursToCharge)
        {
            m_Garage.ChargeElectricVehicleByLicenseNumber(i_LicenseNumber, i_HoursToCharge);
        }

        public bool CheckIfExistingVehicleReport(string i_LicenseNumber)
        {
            return m_Garage.CheckIfExistingVehicleReport(i_LicenseNumber);
        }

        public Dictionary<string, GarageReport> GarageReports
        {
            get
            {
                return m_Garage.GarageReports;
            }
        }
    }
}
