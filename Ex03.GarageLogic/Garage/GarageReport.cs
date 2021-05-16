using System;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class GarageReport
    {
        private string m_OwnerName;
        private string m_OwnersPhoneNumber;
        private Vehicle m_Vehicle;
        private eCarGarageStatus m_Status;
        

        public GarageReport(string i_OwnerName, string i_OwnersPhoneNumber,Vehicle i_Vehicle)
        {
            OwnerName = i_OwnerName;
            OwnersPhoneNumber = i_OwnersPhoneNumber;
            Vehicle = i_Vehicle;
            Status = eCarGarageStatus.InRepair;
        }

        public enum eCarGarageStatus
        {
            InRepair = 1,
            Fixed,
            Paid
        }


        internal eCarGarageStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eCarGarageStatus), value))
                {
                    throw new ArgumentException("Error with CarGarageStatus enum convert ");
                }

                m_Status = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnersPhoneNumber
        {
            get
            {
                return m_OwnersPhoneNumber;
            }
            set
            {
                m_OwnersPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value ?? throw new ArgumentException("Vehicle cannot be null in GarageReport");
            }
        }

    }


}
