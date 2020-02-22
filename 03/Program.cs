using System;
using System.Linq;

namespace _03
{
    /// <summary>
    /// Problem 03
    /// </summary>
    class Program
    {
        private static int _maxCharsPerRow;

        static void Main(string[] args)
        {
            Console.Write("Exercise 03 Description: Write a function that takes a list of strings an prints them, one per line, in a rectangular frame.");
            Console.WriteLine();

            var inputArray = FillArray();
            Console.WriteLine();

            //Prints the array in a rectangular way
            PrintRectangularArrayFrame(inputArray);
            
            Console.ReadKey();
        }


        private static void PrintInvalidParameterAndExit(string paramaterName)
        {
            Console.WriteLine($"[Error] Parameter {paramaterName} is invalid. Please verify it and try again.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static int ParseSize(string size)
        {
            var parsedSize = int.TryParse(size, out var result);
            if (parsedSize) return result;
            return -1;
        }

        private static string[] FillArray()
        {
            Console.Write("Size of the array: ");
            var arraySize = ParseSize(Console.ReadLine()?.Trim());
            if (arraySize == -1) PrintInvalidParameterAndExit("ArraySize");

            //No array size provided. Exit program
            if (arraySize == 0)
                Environment.Exit(0);

            //Initialize Array
            var elementsArray = new string[arraySize];
            //Fill the array with user input.
            for (var i = 1; i <= elementsArray.Length; i++)
            {
                Console.Write($"Enter item #{i} value: ");
                elementsArray[i - 1] = Console.ReadLine();
            }

            return elementsArray;
        }

        private static void PrintSeparatorLine()
        {
            Console.WriteLine(new string('*', _maxCharsPerRow));
        }

        private static void PrintRectangularArrayFrame(string[] array)
        {
            Console.WriteLine("Array rectangular representation: ");

            //Set max char * limit based on greatest element in Array and add some extra chars for formatting
            _maxCharsPerRow = array.OrderBy(x => x.Length).Last().Length + 4;

            PrintSeparatorLine();
            foreach (var item in array)
            {
                PrintRectangularArrayFrameItem(item);
            }
            PrintSeparatorLine();
            }

        private static void PrintRectangularArrayFrameItem(string item)
        {
            var newLine = $"{item}";

            //Calculate missing chars in new row to the right. Also exclude the last 2 chars since those are added in the end
            var missingCharCount = _maxCharsPerRow - newLine.Length -2;
            newLine = newLine.Insert(newLine.Length, new string(' ', missingCharCount -2));
            Console.WriteLine($"* {newLine} *");
        }
    }
}
