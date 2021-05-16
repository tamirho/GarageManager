using System;

namespace Ex03.GarageLogic.VehicleCreator
{
    public class VehicleCreatorException : Exception
    {
        public VehicleCreatorException(string i_ExceptionMessage, Exception i_InnerException)
            : base(string.Format("VehicleCreatorException: {0}", i_ExceptionMessage), i_InnerException)
        {
        }

        public VehicleCreatorException(Exception i_InnerException)
            : base("VehicleCreatorException", i_InnerException)
        {
        }

        public VehicleCreatorException(string i_ExceptionMessage)
            : base(string.Format("VehicleCreatorException: {0}", i_ExceptionMessage))
        {
        }

        public VehicleCreatorException()
            : base("VehicleCreatorException")
        {
        }
    }
}
