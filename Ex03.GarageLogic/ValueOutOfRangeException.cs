using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private static readonly string sr_ExceptionMessage = " ValueOutOfRangeException: {0} is not in the range between {1} to {2}";
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        private readonly float r_InvalidValue;

        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_InvalidValue,
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format(sr_ExceptionMessage, i_InvalidValue, i_MinValue, i_MaxValue), i_InnerException)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
            r_InvalidValue = i_InvalidValue;
        }

        public ValueOutOfRangeException(
            float i_InvalidValue,
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format(sr_ExceptionMessage, i_InvalidValue, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
            r_InvalidValue = i_InvalidValue;
        }

        public ValueOutOfRangeException(
            string i_ExceptionMessage,
            float i_InvalidValue,
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format(i_ExceptionMessage + sr_ExceptionMessage, i_InvalidValue, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
            r_InvalidValue = i_InvalidValue;
        }

        public float InvalidValue
        {
            get
            {
                return r_InvalidValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}