using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ConsoleInputUI
    {
        internal static string GetLicenseNumberFromUser()
        {
            Console.WriteLine("Enter license number:");
            string licenseNumber = Console.ReadLine();
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
            string phoneNumber = Console.ReadLine();

            if (!int.TryParse(phoneNumber, out int _))
            {
                throw new FormatException("Invalid Phone Number Format");
            }

            return phoneNumber;
        }

        internal static string GetAllLettersStringFromUser()
        {
            string userInput = Console.ReadLine().Trim();
            if(userInput.Length == 0)
            {
                throw new FormatException("The input does not match the format");
            }

            foreach(char character in userInput)
            {
                if(!(char.IsLetter(character) || char.IsWhiteSpace(character)))
                {
                    throw new FormatException("The input does not match the format");
                }
            }

            return userInput;
        }

        internal static float GetFloatFromUser()
        {
            string userInput = Console.ReadLine();
            if(!float.TryParse(userInput, out float result))
            {
                throw new FormatException("The input does not match the format");
            }

            return result;
        }

        internal static int GetIntFromUser()
        {
            string userInput = Console.ReadLine();
            if(!int.TryParse(userInput, out int result))
            {
                throw new FormatException("The input does not match the format");
            }

            return result;
        }
    }
}
