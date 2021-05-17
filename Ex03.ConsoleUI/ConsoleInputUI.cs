using System;

namespace Ex03.ConsoleUI
{
    public class ConsoleInputUI
    {
        internal static string GetLicenseNumberFromUser()
        {
            Console.WriteLine("Enter license number:");
            string licenseNumber = GetStringFromUser();

            foreach (char character in licenseNumber)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    throw new FormatException("Invalid License Number Format");
                }
            }

            return licenseNumber;
        }

        internal static string GetPhoneNumberFromUser()
        {
            Console.WriteLine("Enter Phone number:");
            string phoneNumber = GetStringFromUser();

            foreach (char ch in phoneNumber)
            {
                if(!char.IsDigit(ch))
                {
                    throw new FormatException("Invalid Phone Number Format");
                }
            }

            return phoneNumber;
        }

        internal static float GetFloatFromUser()
        {
            string userInput = GetStringFromUser();

            if (!float.TryParse(userInput, out float result))
            {
                throw new FormatException("The input does not match the format");
            }

            return result;
        }

        internal static int GetIntFromUser()
        {
            string userInput = GetStringFromUser();

            if (!int.TryParse(userInput, out int result))
            {
                throw new FormatException("The input does not match the format");
            }

            return result;
        }

        internal static string GetStringFromUser()
        {
            string userInput = Console.ReadLine().Trim();

            if (userInput.Length == 0)
            {
                throw new FormatException("Empty input is invalid");
            }

            return userInput;
        }
    }
}
