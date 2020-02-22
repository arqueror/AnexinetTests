using System;
using System.Collections.Generic;

namespace _06
{
    /// <summary>
    /// Problem 06
    /// </summary>
    class Program
    {
        //Define a dictionary for the base10/roman numeral representation.
        static readonly Dictionary<int, string> RomanNumerals = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        static void Main(string[] args)
        {
            Console.Write("Exercise 06 Description: Write a function that convert the given number into a Roman Numeral");
            Console.WriteLine();

            Console.Write("Number to convert: ");
            var inputValue = Console.ReadLine()?.Trim();
            if (!IsValidValue(inputValue, out var intNumber))
            {
                Console.WriteLine("Invalid input value");
                Environment.Exit(0);
            }

            Console.WriteLine($"Number Roman Number Numeral representation: {IntegerToRomanNumber(intNumber)}");
            Console.ReadKey();
        }

        
        private static string IntegerToRomanNumber(int intValue)
        {
            var result = string.Empty;
            //Loop RomanNumerals dictionary and append key value when key equals intValue, then substract equivalent from intValue and repeat.
            //TODO. This can also be achieved with a recursive function but let's keep it simple for the example
            foreach (var numeral in RomanNumerals)
            {
                while (intValue >= numeral.Key)
                {
                    intValue -= numeral.Key;
                    result += numeral.Value;
                }
            }
            return result;
        }

        //Validates value is a valid number representation
        private static bool IsValidValue(string value, out int result)
        {
            return int.TryParse(value, out result);
        }
    }
}
