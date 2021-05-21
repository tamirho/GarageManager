using System;
using Ex03.GarageLogic.VehicleParts;

namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
        private eCarColor? m_Color;
        private eNumberOfCarDoors? m_NumberOfDoors;

        internal Car() { }

        internal Car(
            string i_LicenseNumber,
            string i_ModelName,
            Wheels i_Wheels,
            EnergyUnit i_EnergyUnit,
            eCarColor i_CarColor,
            eNumberOfCarDoors i_NumberOfDoors)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            Color = i_CarColor;
            NumberOfDoors = i_NumberOfDoors;
        }

        internal Car(string i_LicenseNumber, string i_ModelName, Wheels i_Wheels, EnergyUnit i_EnergyUnit, object[] i_VehicleSpecialParams)
            : base(i_LicenseNumber, i_ModelName, i_Wheels, i_EnergyUnit)
        {
            Color = (eCarColor)i_VehicleSpecialParams[(int)eCarSpecialParams.CarColor];
            NumberOfDoors = (eNumberOfCarDoors)i_VehicleSpecialParams[(int)eCarSpecialParams.NumberOfCarDoors];
        }

        public enum eCarSpecialParams
        {
            CarColor = 0,
            NumberOfCarDoors
        }

        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }

        public enum eNumberOfCarDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public eCarColor? Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eCarColor), value))
                {
                    throw new ArgumentException("Error with eCarColor conversion");
                }

                m_Color = value;
            }
        }

        public eNumberOfCarDoors? NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eNumberOfCarDoors), value))
                {
                    throw new ArgumentException("Error with eNumberOfDoors conversion");
                }

                m_NumberOfDoors = value;
            }
        }

        public override Tuple<string, object, Type>[] GetSpecialParamsDescriptions()
        {
            Tuple<string, object, Type>[] specialParamsArr =
                {
                    new Tuple<string, object, Type>("Car color", new eCarColor(), typeof(eCarColor)),
                    new Tuple<string, object, Type>(
                        "Number of doors",
                        new eNumberOfCarDoors(),
                        typeof(eNumberOfCarDoors))
                };

            return specialParamsArr;
        }

        public override void SetSpecialParams(object[] i_SpecialParamsInputs)
        {
            Color = (eCarColor)i_SpecialParamsInputs[(int)eCarSpecialParams.CarColor];
            NumberOfDoors = (eNumberOfCarDoors)i_SpecialParamsInputs[(int)eCarSpecialParams.NumberOfCarDoors];
        }

        public override string ToString()
        {
            return string.Format(
                @"Car:
{0}
Color: {1}
Number of doors: {2}",
                base.ToString(),
                m_Color,
                m_NumberOfDoors);
        }
    }
}
