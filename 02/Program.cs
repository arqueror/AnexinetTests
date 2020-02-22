using System;
namespace _02
{
    /// <summary>
    /// Problem 02
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 02 Description: Write a function that returns the elements on odd positions in an array");
            Console.WriteLine();

            var elementsArray = FillArray();

            Console.WriteLine();
            var oddItems = string.Empty;
            //Show the array elements in odd positions
            for (var i = 1; i <= elementsArray.Length; i++)
            {
                if (IsOdd(i))
                    oddItems += elementsArray[i - 1] + ' ';
            }

            //Remove last empty char
            oddItems.Trim();
            if(string.IsNullOrEmpty(oddItems))
                Console.WriteLine("No odd items to show.");
            else
                Console.WriteLine($"Array odd items are: {oddItems}");

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

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
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
    }
}
