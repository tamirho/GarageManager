using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private readonly Dictionary<string, GarageReport> r_GarageReportDictionary;

        public Garage()
        {
            r_GarageReportDictionary = new Dictionary<string, GarageReport>();
        }

        public Dictionary<string, GarageReport> GarageReports
        {
            get
            {
                return r_GarageReportDictionary;
            }
        }

        public void InsertNewVehicle(string i_OwnerName, string i_OwnersPhoneNumber, Vehicle i_Vehicle)
        {
            if(r_GarageReportDictionary.ContainsKey(i_Vehicle.LicenseNumber))
            {
                r_GarageReportDictionary[i_Vehicle.LicenseNumber].Status = GarageReport.eVehicleGarageStatus.InRepair;
            }
            else
            {
                GarageReport newGarageReport = new GarageReport(i_OwnerName, i_OwnersPhoneNumber, i_Vehicle);
                r_GarageReportDictionary.Add(i_Vehicle.LicenseNumber, newGarageReport);
            }
        }

        public List<string> GetLicenseListOfExistingVehicle()
        {
            return r_GarageReportDictionary.Keys.ToList();
        }

        public List<string> GetLicenseListOfExistingVehicle(GarageReport.eVehicleGarageStatus i_Status)
        {
            if(!Enum.IsDefined(typeof(GarageReport.eVehicleGarageStatus), i_Status))
            {
                throw new ArgumentException("Error with eVehicleGarageStatus conversion");
            }

            List<string> theFilteredLicenseNumberList = new List<string>();

            foreach(KeyValuePair<string, GarageReport> pairReport in r_GarageReportDictionary)
            {
                if(pairReport.Value.Status == i_Status)
                {
                    theFilteredLicenseNumberList.Add(pairReport.Key);
                }
            }

            return theFilteredLicenseNumberList;
        }

        public void ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageReport.eVehicleGarageStatus i_Status)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            theReport.Status = i_Status;
        }

        public void InflateVehicleWheelsPressureToMaxByLicenseNumber(string i_LicenseNumber)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            foreach(Wheel theWheel in theReport.Vehicle.Wheels.WheelsList)
            {
                theWheel.AddAirPressure(theWheel.MaxAirPressure - theWheel.CurrentAirPressure);
            }
        }

        public void RefuelVehicleByLicenseNumber(string i_LicenseNumber, FuelEnergyUnit.eFuelType i_FuelType, float i_FuelLiters)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            if (!(theReport.Vehicle.EnergyUnit is FuelEnergyUnit theEnergyUnit))
            {
                throw new GarageException("Can't refuel non-fuel energy unit");
            }

            try
            {
                theEnergyUnit.AddFuel(i_FuelLiters, i_FuelType);
            }
            catch(Exception exception)
            {
                throw new GarageException(
                    string.Format("Can't refuel vehicle with license number {0}", i_LicenseNumber),
                    exception);
            }
        }

        public void ChargeElectricVehicleByLicenseNumber(string i_LicenseNumber, float i_HoursToCharge)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            if (!(theReport.Vehicle.EnergyUnit is ElectricEnergyUnit theEnergyUnit))
            {
                throw new GarageException("Can't charge non-electric energy unit");
            }

            try
            {
                theEnergyUnit.AddDrivingHours(i_HoursToCharge);
            }
            catch(Exception exception)
            {
                throw new GarageException(
                    string.Format("Can't charge vehicle with license number {0}", i_LicenseNumber),
                    exception);
            }
        }

        private GarageReport getGarageReportByLicenseNumber(string i_LicenseNumber)
        {
            if(i_LicenseNumber == null)
            {
                throw new GarageException(
                    "Invalid license number, Null was given",
                    new ArgumentNullException());
            }

            if(!r_GarageReportDictionary.ContainsKey(i_LicenseNumber))
            {
                throw new GarageException(
                    string.Format("Car with {0} license number can't be found in the garage", i_LicenseNumber),
                    new KeyNotFoundException());
            }

            return r_GarageReportDictionary[i_LicenseNumber];
        }

        public bool CheckIfExistingVehicleReport(string i_LicenseNumber)
        {
            return i_LicenseNumber != null && r_GarageReportDictionary.ContainsKey(i_LicenseNumber);
        }
    }
}
