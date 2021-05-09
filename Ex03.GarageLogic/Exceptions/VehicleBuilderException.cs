using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class VehicleBuilderException : Exception
    {
        public VehicleBuilderException(string i_ExceptionMessage, Exception i_InnerException)
            : base(string.Format("VehicleBuilderException: {0}", i_ExceptionMessage), i_InnerException)
        {
        }

        public VehicleBuilderException(Exception i_InnerException)
            : base("VehicleBuilderException", i_InnerException)
        {
        }

        public VehicleBuilderException(string i_ExceptionMessage)
            : base(string.Format("VehicleBuilderException: {0}", i_ExceptionMessage))
        {
        }

        public VehicleBuilderException()
            : base("VehicleBuilderException")
        {
        }
    }
}
