using System;

namespace _05
{
    /// <summary>
    /// Problem 05
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Exercise 05 Description: Given a number between 0 and 1 (e.g. 0.15), print its binary representation. If the number\r\ncannot be represented accurately in binary with at most 32 characters, just print 'Error'");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Number between 0 - 1: ");
            var inputNumber = Console.ReadLine()?.Trim();
            if (inputNumber == null || !IsValidValue(inputNumber))
            {
                Console.WriteLine("Invalid input value");
                Environment.Exit(0);
            }

            // convert value to its binary representation
            var convertedBinary = "";
            if (inputNumber.Contains('.'))
            {
                foreach (var t in inputNumber)
                {
                    if (t != '.')
                        convertedBinary += PadBinaryString(Convert.ToString(Convert.ToUInt32(t), 2), 8);
                    else
                        //Append binary representation of '.' directly
                        convertedBinary += "00101110";
                }
            }
            else convertedBinary = Convert.ToString(Convert.ToUInt32(inputNumber), 2);

            if (convertedBinary.Length < 32)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            Console.WriteLine($"Number binary representation: {convertedBinary}");
            Console.ReadKey();
        }

        //Validates value is between 0 - 1 and it is a valid number representation.
        private static bool IsValidValue(string value)
        {
            var isValid = decimal.TryParse(value, out var result);
            if ((result < 0 || result > 1) || !isValid) return false;
            return true;
        }

        //Pads binary number to the specified length by using 0's. For this example we need padding of 8
        private static string PadBinaryString(string value, int len)
        {
            char[] c = value.ToCharArray();
            if (c.Length >= len) return value;
            for (int a = 0; a < (len - c.Length); a++)
                value = "0" + value;

            return value;
        }
    }
}
