using System;
using System.Runtime.CompilerServices;

namespace _01
{
    /// <summary>
    /// Problem 01
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DateTime _date1, _date2;

            Console.WriteLine("Exercise 01 Description: Write a function that receives 2 Date parameters and returns the time difference in minutes");
            Console.WriteLine();
            Console.Write("First date: ");

            _date1 = ParseDate(Console.ReadLine()?.Trim());
            if (_date1 == DateTime.MinValue) PrintInvalidDateAndExit();

            Console.Write("Second date: ");
            _date2 = ParseDate(Console.ReadLine()?.Trim());
            if (_date2 == DateTime.MinValue) PrintInvalidDateAndExit();

            Console.WriteLine();
            Console.Write($"The difference in minutes is: {CalculateDateDiffInMinutes(_date1, _date2)} minutes");
            Console.ReadKey();
        }

        private static DateTime ParseDate(string date)
        {
            var parsedDate = DateTime.TryParse(date, out var result);
            if (parsedDate) return result;
            return DateTime.MinValue;
        }

        private static void PrintInvalidDateAndExit()
        {
            Console.WriteLine("Invalid parameter. Please check you are using a valid date format and try again.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static string CalculateDateDiffInMinutes(DateTime date1, DateTime date2)
        {
            var diff = (date2 - date1).TotalMinutes;

            //Fix negative result before displaying it
            if (diff < 0) diff *= -1;
            return diff.ToString();
        }
    }
}
