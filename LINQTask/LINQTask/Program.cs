using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LINQTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            BigInteger[] array = fibonacci.CreateArray(200);
            
            Console.WriteLine($"Prime numbers count {array.FindPrimesCount()}");
            Console.WriteLine($"Special numbers count(value div sum digits ) {array.FindSpecialNumbers()}");
            Console.WriteLine($"Has numbers divided by five {array.HasNumberDividedByFive()}");

            Console.WriteLine("Sqrt with digit two ");
            BigInteger[] newArray = array.SqrtWithDigitTwo();
            foreach (BigInteger num in newArray)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            newArray = array.SortBySecondDigit();
            Console.WriteLine("Sorted by second digit");
            foreach (BigInteger a in newArray)
            {
                Console.Write(a + " ");
            }
            List<string> newStringArray = new List<string>();
            Console.WriteLine();
            Console.WriteLine("Special two digits");
            newStringArray = array.GetSpecialLastTwoDigits();
            foreach (string a in newStringArray)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"MaxSumSqrtDigitsValue { array.MaxSumSqrtDigits()}");
            Console.WriteLine($"AverageCountOfZeros {array.AverageCountOfZeros()}");
            Console.ReadKey();
        }
    }
}
