using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LINQTask
{
    static class LINQSorter
    {
        public static int FindPrimesCount(this BigInteger[] array)
        {

            BigInteger[] a = array.Where(x => x % 2 != 0 || x == 1 || x == 0 || x == 2).
                Where(x => x.IsPrime()).
                ToArray();
            return a.Length;
        }
    public static bool IsPrime(this BigInteger x)
    {
            Random rnd = new Random();
            if (x == 2)
                return true;
            for (int i = 0; i < 100; i++)
            {
                BigInteger a = (rnd.Next() % (x - 2)) + 2;
                if (BigInteger.GreatestCommonDivisor(a, x) != 1)
                    return false;
                if (Pows(a, x - 1, x) != 1)
                    return false;
            }
            return true;
        }
        public static BigInteger Pows(BigInteger a, BigInteger b, BigInteger m)
        {
            if (b == 0)
                return 1;
            if (b % 2 == 0)
            {
                BigInteger t = Pows(a, b / 2, m);
                return Mul(t, t, m) % m;
            }
            return (Mul(Pows(a, b - 1, m), a, m)) % m;
        }

        static BigInteger Mul(BigInteger a, BigInteger b, BigInteger m)
        {
            if (b == 1)
                return a;
            if (b % 2 == 0)
            {
                BigInteger t = Mul(a, b / 2, m);
                return (2 * t) % m;
            }
            return (Mul(a, b - 1, m) + a) % m;
        }
        public static int FindSpecialNumbers(this BigInteger[] array)
        {

            BigInteger[] a = array.Where(x => x!=0).Where(x => x % x.FindSumOfDigits() == 0).ToArray();
            return a.Length ;
        }

        public static int FindSpecialNumbers1(this BigInteger[] array)
        {

            BigInteger[] a = array.Where(x => x != 0).ToArray();

            for(int i = 0; i< a.Length; i++)
            {
                string result = a[i].ToString();
                var intList = result.Select(digit => int.Parse(digit.ToString())).Sum();
                Console.WriteLine(intList);
            }

            return a.Length;
        }

        public static bool HasNumberDividedByFive(this BigInteger[] array)
        {
            BigInteger[] a = array.Where(x => x % 5 == 0).ToArray();
            if(a.Length > 0)
            {
                return true;
            }
            return false;
        }

        public static BigInteger[] SqrtWithDigitTwo(this BigInteger[] array)
        {
            BigInteger[] a = array.Where(x => x.ToString().Contains("2")).Select(x => (BigInteger)Math.Floor(Math.Sqrt((double)x))).ToArray();
            return a;
        }

        public static BigInteger[] SortBySecondDigit(this BigInteger[] array)
        {
            var a = array.OrderBy(x => x.FindSecondDigit()).ThenBy(x => x).ToArray();

            return a;
        }



        public static int FindSumOfDigits(this BigInteger number)
        {
            BigInteger sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return (int)sum;
        }

        public static int FindSecondDigit(this BigInteger number)
        {
            BigInteger secondDigit =0;
            while (number > 9)
            {
                secondDigit = (BigInteger)number % 10;
                number /= 10;
            }
            Console.WriteLine(secondDigit);
            return (int)secondDigit;
        }
    }

    
}
