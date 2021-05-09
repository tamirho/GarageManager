﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private Dictionary<string, GarageReport> m_GarageReportDictionary;

        public Garage()
        {
            m_GarageReportDictionary = new Dictionary<string, GarageReport>();
        }

        public Dictionary<string, GarageReport> GarageReports
        {
            get
            {
                return m_GarageReportDictionary;
            }
        }

        public void InsertNewVehicle(string i_OwnerName, string i_OwnersPhoneNumber, Vehicle i_Vehicle)
        {
            if(m_GarageReportDictionary.ContainsKey(i_Vehicle.LicenseNumber))
            {
                m_GarageReportDictionary[i_Vehicle.LicenseNumber].Status = GarageReport.eCarGarageStatus.InRepair;
            }
            else
            {
                GarageReport newGarageReport = new GarageReport(i_OwnerName, i_OwnersPhoneNumber, i_Vehicle);
                m_GarageReportDictionary.Add(i_Vehicle.LicenseNumber, newGarageReport);
            }
        }

        public List<string> GetLicenseListOfExistingVehicle()
        {
            return m_GarageReportDictionary.Keys.ToList();
        }

        public List<string> GetLicenseListOfExistingVehicle(GarageReport.eCarGarageStatus i_Status)
        {
            List<string> theFilteredLicenseNumberList = new List<string>();
            foreach(KeyValuePair<string, GarageReport> pairReport in m_GarageReportDictionary)
            {
                if(pairReport.Value.Status == i_Status)
                {
                    theFilteredLicenseNumberList.Add(pairReport.Key);
                }
            }

            return theFilteredLicenseNumberList.;
        }

        public void ChangeVehicleStatusByLicenseNumber(string i_LicenseNumber, GarageReport.eCarGarageStatus i_Status)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            theReport.Status = i_Status;
        }

        public void InflateVehicleWheelsPressureToMaxByLicenseNumber(string i_LicenseNumber)
        {
            GarageReport theReport = getGarageReportByLicenseNumber(i_LicenseNumber);
            foreach (Wheel theWheel in theReport.Vehicle.WheelsList)
            {
                theWheel.AddAirPressure(theWheel.MaxAirPressure - theWheel.CurrentAirPressure);
            }
        }

        public void RefuelVehicleByLicenseNumber(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLiters)
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
            if(!m_GarageReportDictionary.ContainsKey(i_LicenseNumber))
            {
                throw new GarageException(
                    string.Format("Car with {0} license number can't be found in the garage", i_LicenseNumber),
                    new KeyNotFoundException());
            }

            return m_GarageReportDictionary[i_LicenseNumber];
        }
    }
}