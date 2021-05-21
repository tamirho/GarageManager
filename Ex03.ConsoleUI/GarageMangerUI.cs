using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.VehicleCreator;
using Ex03.GarageLogic.VehicleParts;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI
{
    public class GarageMangerUI
    {
        private readonly GarageManager r_GarageManager;

        public GarageMangerUI()
        {
            r_GarageManager = new GarageManager();
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
                Console.WriteLine(
                    string.Format(
                        @"~ Main menu ~
{0}
Choose an option:",
                        buildStrMenuFromEnum(new eMainMenuOptions())));

                bool validInput;
                int userInput = 0;
                do
                {
                    try
                    {
                        userInput = ConsoleInputUI.GetIntFromUser();
                        validInput = Enum.IsDefined(typeof(eMainMenuOptions), userInput);
                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        validInput = false;
                    }

                    if(!validInput)
                    {
                        Console.WriteLine("Invalid input, Please try again.");
                    }
                }
                while(!validInput);

                eMainMenuOptions userChoice = (eMainMenuOptions)userInput;

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

                Console.Write("Press any key to continue");
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

                if(!r_GarageManager.CheckIfExistingVehicleReport(licenseNumber))
                {
                    Console.WriteLine("Enter owner name:");
                    string ownerName = ConsoleInputUI.GetStringFromUser();
                    string ownersPhoneNumber = ConsoleInputUI.GetPhoneNumberFromUser();
                    Vehicle theVehicle = getAndBuildNewVehicleFromUserInputs();
                    theVehicle.LicenseNumber = licenseNumber;
                    r_GarageManager.InsertVehicleToGarage(ownerName, ownersPhoneNumber, theVehicle);
                    Console.WriteLine("The vehicle has been added successfully");
                }
                else
                {
                    r_GarageManager.ChangeVehicleStatusByLicenseNumber(
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

        private Vehicle getAndBuildNewVehicleFromUserInputs()
        {
            Console.WriteLine("Choose vehicle type:");
            VehicleCreator.eVehiclesType vehiclesType =
                (VehicleCreator.eVehiclesType)getUserInputFromEnumMenu(new VehicleCreator.eVehiclesType());
            Vehicle theVehicle = r_GarageManager.CreateVehicle(vehiclesType);

            Console.WriteLine("Enter model name:");
            theVehicle.ModelName = ConsoleInputUI.GetStringFromUser();
            Console.WriteLine("Enter wheels manufacturer name:");
            string manufactureName = ConsoleInputUI.GetStringFromUser();
            theVehicle.Wheels.SetWheelsManufacturerName(manufactureName);
            Console.WriteLine("Enter the air pressure of the wheels: ");
            float currentAirPressure = ConsoleInputUI.GetFloatFromUser();
            theVehicle.Wheels.SetWheelsAirPressure(currentAirPressure);
            Console.WriteLine(
                theVehicle.EnergyUnit is FuelEnergyUnit
                    ? "Enter how many liters left in the engine: "
                    : "Enter how many hours left in the battery amount: ");
            float currentEnergyAmount = ConsoleInputUI.GetFloatFromUser();
            theVehicle.EnergyUnit.CurrentEnergyAmount = currentEnergyAmount;
            object[] specialParams = getVehicleSpecialParamsFromUser(theVehicle);
            theVehicle.SetSpecialParams(specialParams);

            return theVehicle;
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
                        theLicenseList = r_GarageManager.GetLicenseListOfExistingVehicle();
                        break;
                    case eVehiclesLicensesMenuOptions.DisplayVehiclesLicensesByStatus:
                        Console.WriteLine("Choose status: ");
                        GarageReport.eVehicleGarageStatus statusFilter =
                            (GarageReport.eVehicleGarageStatus)getUserInputFromEnumMenu(
                                new GarageReport.eVehicleGarageStatus());

                        theLicenseList = r_GarageManager.GetLicenseListOfExistingVehicle(statusFilter);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine(@"
Licenses list:");
                foreach (string licensesNumber in theLicenseList)
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
                r_GarageManager.ChangeVehicleStatusByLicenseNumber(licenseNumber, newStatus);
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
                r_GarageManager.InflateVehicleWheelsPressureToMaxByLicenseNumber(licenseNumber);
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
                FuelEnergyUnit.eFuelType fuelType = (FuelEnergyUnit.eFuelType)getUserInputFromEnumMenu(new FuelEnergyUnit.eFuelType());
                Console.WriteLine("Enter amount of liters:");
                float fuelLiters = ConsoleInputUI.GetFloatFromUser();
                r_GarageManager.RefuelVehicleByLicenseNumber(licenseNumber, fuelType, fuelLiters);
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
                r_GarageManager.ChargeElectricVehicleByLicenseNumber(licenseNumber, minutesToCharge / 60);
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
            foreach(GarageReport theReport in r_GarageManager.GarageReports.Values)
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

        private object[] getVehicleSpecialParamsFromUser(Vehicle i_Vehicle)
        {
            Tuple<string, object, Type>[] specialParamsArr = i_Vehicle.GetSpecialParamsDescriptions();
            object[] returnValues = new object[specialParamsArr.Length];
            int writeIndex = 0;

            foreach(Tuple<string, object, Type> param in specialParamsArr)
            {
                Enum theEnum = param.Item2 as Enum;
                if(theEnum != null)
                {
                    Console.WriteLine(string.Format("{0}: ", param.Item1));
                    returnValues[writeIndex] = getUserInputFromEnumMenu(theEnum);
                }
                else
                {
                    Console.WriteLine(string.Format("Please enter {0}:", param.Item1));
                    string userInput = ConsoleInputUI.GetStringFromUser();
                    returnValues[writeIndex] = Convert.ChangeType(userInput, param.Item3);
                }

                writeIndex++;
            }

            return returnValues;
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
            Console.WriteLine(
                string.Format(
                    @"{0}
Choose an option:",
                    buildStrMenuFromEnum(i_Enum)));

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
