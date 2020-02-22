using System;

namespace _07
{
    /// <summary>
    /// Problem 07
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Exercise 07 Description: Write a function that receives n (a number) as a parameter and prints all valid (properly\r\nopened and closed) combinations of n-pairs of parentheses");
            Console.WriteLine();

            Console.Write("Number: ");
            var inputValue = Console.ReadLine()?.Trim();
            if (!IsValidValue(inputValue, out var intNumber))
            {
                Console.WriteLine("Invalid input value");
                Environment.Exit(0);
            }

            Console.WriteLine(GenerateParenthesis(intNumber));
            Console.ReadKey();
        }


        
        private static string GenerateParenthesis(int n)
        {
            var finalResult = "";
            //Inner function needs 4 parameters, but for user it's more natural to only have 1.
            GenerateAllParenthesisCombinations(3, 3, ref finalResult);
            finalResult = finalResult.Remove(finalResult.Length - 2, 2);
            return finalResult;
        }

        /*
         * 1. add open parenthesis to new string
         * 2. if left was added, then we need to add new open parenthesis and a closing parenthesis calling funtion again with minus 1 depending if open/close
         * 3. repeat until open and close count is equal indicating we have all parenthesis we need for a given 'n' value
         *
         */
        public static void GenerateAllParenthesisCombinations(int leftParCount, int rightParCount, ref string concatenatedResult,  string currCombination = "" )
        {
            //Opening and close are equal. Append result to final string
            if (leftParCount == 0 && rightParCount == 0)
                concatenatedResult += $"{currCombination}, ";

            //Closing are more than openings
            if (leftParCount > rightParCount) return;

            //Append one Open and reduce count by 1 since we still have opening parenthesis to be added
            if (leftParCount > 0)
                GenerateAllParenthesisCombinations(leftParCount - 1, rightParCount, ref concatenatedResult, currCombination + "(");

            //Append one Close and reduce count by 1 since we still have closing parenthesis to be added
            if (rightParCount > 0)
                GenerateAllParenthesisCombinations(leftParCount, rightParCount - 1, ref concatenatedResult, currCombination + ")");
        }

        //Validates value is a valid number representation
        private static bool IsValidValue(string value, out int result)
        {
            return int.TryParse(value, out result);
        }
    }
}
