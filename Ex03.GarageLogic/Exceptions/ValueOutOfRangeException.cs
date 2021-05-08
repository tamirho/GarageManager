using System;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private float m_InvalidValue;
        private static string m_ExceptionMessage = "{0} is not in the range between {1} to {2}";

        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_InvalidValue,
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format(m_ExceptionMessage, i_InvalidValue, i_MinValue, i_MaxValue), i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_InvalidValue = i_InvalidValue;
        }

        public ValueOutOfRangeException(
            float i_InvalidValue,
            float i_MinValue,
            float i_MaxValue)
            : base(string.Format(m_ExceptionMessage, i_InvalidValue, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_InvalidValue = i_InvalidValue;
        }

        public float InvalidValue
        {
            get
            {
                return m_InvalidValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
    }
}