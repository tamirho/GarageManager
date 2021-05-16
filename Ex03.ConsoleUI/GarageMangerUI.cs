using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI
{
    public class GarageMangerUI
    {
        private readonly GarageManager m_GarageManager;

        public GarageMangerUI()
        {
            m_GarageManager = new GarageManager();
        }

        public enum eMainMenuOptions
        {
            InsertVehicleToGarage = 1,
            DisplayVehiclesLicenseList,
            ChangeVehicleStatus,
            InflateVehicleWheels,
            RefuelVehicle,
            ChargeElectricVehicle,
            DisplayAllVehiclesData,
            Exit
        }

        public void Start()
        {
            bool exitFlag = false;
            do
            {
                Console.WriteLine("~ Main menu ~");
                Console.WriteLine(buildStrMenuFromEnum(new eMainMenuOptions()));

                string userInputString = Console.ReadLine();
                int userInputInt;
                while (!int.TryParse(userInputString, out userInputInt)
                       || !Enum.IsDefined(typeof(eMainMenuOptions), userInputInt))
                {
                    Console.WriteLine("Invalid input, Please try again.");
                    userInputString = Console.ReadLine();
                }
                eMainMenuOptions userChoice = (eMainMenuOptions)userInputInt;

                switch(userChoice)
                {
                    case eMainMenuOptions.InsertVehicleToGarage:
                        insertVehicleToGarage();
                        break;
                    case eMainMenuOptions.DisplayVehiclesLicenseList:
                        displayVehiclesLicensesList();
                        break;
                    case eMainMenuOptions.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case eMainMenuOptions.InflateVehicleWheels:
                        inflateVehicleWheels();
                        break;
                    case eMainMenuOptions.RefuelVehicle:
                        refuelVehicle();
                        break;
                    case eMainMenuOptions.ChargeElectricVehicle:
                        chargeElectricVehicle();
                        break;
                    case eMainMenuOptions.DisplayAllVehiclesData:
                        displayAllVehiclesData();
                        break;
                    case eMainMenuOptions.Exit:
                        exitFlag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.Write("To continue press any key");
                Console.ReadLine();
                Console.Clear();
            }
            while(exitFlag == false);
        }

        private void insertVehicleToGarage()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Insert Vehicle To Garage ~");
                string licenseNumber = ConsoleInputUI.GetLicenseNumberFromUser();

                if(!m_GarageManager.CheckIfExistingVehicleReport(licenseNumber))
                {
                    Console.WriteLine("Enter owner name:");
                    string ownerName = ConsoleInputUI.GetAllLettersStringFromUser();
                    string ownersPhoneNumber = ConsoleInputUI.GetPhoneNumberFromUser();
                    Console.WriteLine("Please choose vehicle type:");
                    eVehiclesType vehiclesType = (eVehiclesType)getUserInputFromEnumMenu(new eVehiclesType());
                    Console.WriteLine("Enter model name:");
                    string modelName = Console.ReadLine();
                    Console.WriteLine("Enter wheels manufacturer name:");
                    string wheelsManufacturerName = ConsoleInputUI.GetAllLettersStringFromUser();
                    object[] specialParams = getSpecialParams(vehiclesType);

                    m_GarageManager.CreateAndInsertNewVehicle(
                        ownerName,
                        ownersPhoneNumber,
                        vehiclesType,
                        licenseNumber,
                        modelName,
                        wheelsManufacturerName,
                        specialParams);

                    Console.WriteLine("The vehicle has been added successfully");
                }
                else
                {
                    m_GarageManager.ChangeVehicleStatusByLicenseNumber(
                        licenseNumber,
                        GarageReport.eVehicleGarageStatus.InRepair);
                    Console.WriteLine("The vehicle is already in the garage, the status has been changed to InRepair");

                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Can't insert vehicle");
                while(exception != null)
                {
                    Console.WriteLine(exception.Message);
                    exception = exception.InnerException;
                }
            }
        }

        public enum eVehiclesLicensesMenuOptions
        {
            DisplayAllVehiclesLicenses = 1,
            DisplayVehiclesLicensesByStatus
        }

        private void displayVehiclesLicensesList()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Display Vehicles Licenses List ~");
                eVehiclesLicensesMenuOptions menuOption =
                    (eVehiclesLicensesMenuOptions)getUserInputFromEnumMenu(new eVehiclesLicensesMenuOptions());
                List<string> theLicenseList;
                switch(menuOption)
                {
                    case eVehiclesLicensesMenuOptions.DisplayAllVehiclesLicenses:
                        theLicenseList = m_GarageManager.GetLicenseListOfExistingVehicle();
                        break;
                    case eVehiclesLicensesMenuOptions.DisplayVehiclesLicensesByStatus:
                        Console.WriteLine("Choose status: ");
                        GarageReport.eVehicleGarageStatus statusFilter =
                            (GarageReport.eVehicleGarageStatus)getUserInputFromEnumMenu(
                                new GarageReport.eVehicleGarageStatus());

                        theLicenseList = m_GarageManager.GetLicenseListOfExistingVehicle(statusFilter);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                foreach(string licensesNumber in theLicenseList)
                {
                    Console.WriteLine(licensesNumber);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Can't display licenses list");
                printExceptionStack(exception);
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Change Vehicle Status ~");
                string licenseNumber = ConsoleInputUI.GetLicenseNumberFromUser();
                Console.WriteLine("Choose status: ");
                GarageReport.eVehicleGarageStatus newStatus =
                    (GarageReport.eVehicleGarageStatus)getUserInputFromEnumMenu(new GarageReport.eVehicleGarageStatus());
                m_GarageManager.ChangeVehicleStatusByLicenseNumber(licenseNumber, newStatus);
                Console.WriteLine("Status has been updated successfully");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Can't change vehicle status");
                printExceptionStack(exception);
            }
        }

        private void inflateVehicleWheels()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Inflate Vehicle Wheels ~");
                string licenseNumber = ConsoleInputUI.GetLicenseNumberFromUser();
                m_GarageManager.InflateVehicleWheelsPressureToMaxByLicenseNumber(licenseNumber);
                Console.WriteLine("The wheels has been inflated to the maximum pressure successfully");
            }
            catch(Exception exception)
            {
                Console.WriteLine("Can't inflate vehicle wheels");
                printExceptionStack(exception);
            }
        }

        private void refuelVehicle()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Refuel Vehicle ~");
                string licenseNumber = ConsoleInputUI.GetLicenseNumberFromUser();
                Console.WriteLine("Choose fuel type:");
                eFuelType fuelType = (eFuelType)getUserInputFromEnumMenu(new eFuelType());
                Console.WriteLine("Enter amount of liters:");
                float fuelLiters = ConsoleInputUI.GetFloatFromUser();
                m_GarageManager.RefuelVehicleByLicenseNumber(licenseNumber, fuelType, fuelLiters);
                Console.WriteLine("Vehicle has been refueled successfully");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Can't refuel vehicle");
                printExceptionStack(exception);
            }
        }

        private void chargeElectricVehicle()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("~ Charge Electric Vehicle ~");
                string licenseNumber = ConsoleInputUI.GetLicenseNumberFromUser();
                Console.WriteLine("Enter the number of minutes you want to recharge:");
                float minutesToCharge = ConsoleInputUI.GetFloatFromUser();
                m_GarageManager.ChargeElectricVehicleByLicenseNumber(licenseNumber, minutesToCharge / 60);
                Console.WriteLine("Vehicle has been charged successfully.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Can't charge electric vehicle.");
                printExceptionStack(exception);
            }
        }

        private void displayAllVehiclesData()
        {
            Console.Clear();
            Console.WriteLine("~ Display All Vehicles Data ~");

            StringBuilder vehiclesDataList = new StringBuilder();
            foreach(GarageReport theReport in m_GarageManager.GarageReports.Values)
            {
                vehiclesDataList.AppendFormat(
                    @"
{0}
-------------------------
",
                    theReport);
            }

            Console.WriteLine(vehiclesDataList.ToString());
        }

        private object[] getSpecialParams(eVehiclesType i_VehiclesType)
        {
            object[] specialParams = null;
            switch (i_VehiclesType)
            {
                case eVehiclesType.NormalBike:
                case eVehiclesType.ElectricBike:
                    specialParams = new object[Enum.GetValues(typeof(Bike.eBikeSpecialParams)).Length];
                    Console.WriteLine("Enter engine volume:");
                    specialParams[(int)Bike.eBikeSpecialParams.EngineVolume] = ConsoleInputUI.GetIntFromUser();
                    Console.WriteLine("Choose license type:");
                    specialParams[(int)Bike.eBikeSpecialParams.LicenseType] =
                        (Bike.eLicenseType)getUserInputFromEnumMenu(new Bike.eLicenseType());
                    break;
                case eVehiclesType.NormalCar:
                case eVehiclesType.ElectricCar:
                    specialParams = new object[Enum.GetValues(typeof(Car.eCarSpecialParams)).Length];
                    Console.WriteLine("Choose car color:");
                    specialParams[(int)Car.eCarSpecialParams.CarColor] =
                        (Car.eCarColor)getUserInputFromEnumMenu(new Car.eCarColor());
                    Console.WriteLine("Choose number of doors:");
                    specialParams[(int)Car.eCarSpecialParams.NumberOfCarDoors] =
                        (Car.eNumberOfCarDoors)getUserInputFromEnumMenu(new Car.eNumberOfCarDoors());
                    break;
                case eVehiclesType.Truck:
                    specialParams = new object[Enum.GetValues(typeof(Truck.eTruckSpecialParams)).Length];
                    Console.WriteLine("Is driving hazardous materials?");
                    specialParams[(int)Truck.eTruckSpecialParams.IsDrivesHazardousMaterials] =
                        (Truck.eHazardousMaterials)getUserInputFromEnumMenu(new Truck.eHazardousMaterials());
                    Console.WriteLine("Enter max capacity weight:");
                    specialParams[(int)Truck.eTruckSpecialParams.MaxCapacityWeight] = ConsoleInputUI.GetFloatFromUser();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_VehiclesType), i_VehiclesType, null);
            }

            return specialParams;
        }

        private string buildStrMenuFromEnum(Enum i_Enum)
        {
            StringBuilder menu = new StringBuilder();
            foreach (object enumValue in Enum.GetValues(i_Enum.GetType()))
            {
                StringBuilder option = new StringBuilder();
                foreach (char letter in enumValue.ToString())
                {
                    if(char.IsUpper(letter))
                    {
                        option.Append(" ");
                    }
                    option.Append(letter);
                }

                menu.AppendFormat("{0}. {1}{2}", (int)enumValue, option, Environment.NewLine);
            }

            return menu.ToString();
        }

        private int getUserInputFromEnumMenu(Enum i_Enum)
        {
            Console.Write(buildStrMenuFromEnum(i_Enum));
            string userInputString = Console.ReadLine();
            return int.Parse(userInputString);
        }

        private void printExceptionStack(Exception i_Exception)
        {
            while (i_Exception != null)
            {
                Console.WriteLine(i_Exception.Message);
                i_Exception = i_Exception.InnerException;
            }
        }
    }
}
