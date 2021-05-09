using System;
namespace Ex03.GarageLogic.Exceptions
{
    class GarageException : Exception
    {
        public GarageException(string i_ExceptionMessage, Exception i_InnerException)
            : base(string.Format("GarageException: {0}", i_ExceptionMessage), i_InnerException)
        {
        }

        public GarageException(Exception i_InnerException)
            : base("GarageException", i_InnerException)
        {
        }

        public GarageException(string i_ExceptionMessage)
            : base(string.Format("GarageException: {0}", i_ExceptionMessage))
        {
        }

        public GarageException()
            : base("GarageException")
        {
        }
    }
}
