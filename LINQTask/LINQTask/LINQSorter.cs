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

        //public static int FindSpecialNumbers1(this BigInteger[] array)
        //{

        //    BigInteger[] a = array.Where(x => x != 0).ToArray();

        //    for(int i = 0; i< a.Length; i++)
        //    {
        //        string result = a[i].ToString();
        //        var intList = result.Select(digit => int.Parse(digit.ToString())).Sum();
        //        Console.WriteLine(intList);
        //    }

        //    return a.Length;
        //}

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

        public static List<string> GetSpecialLastTwoDigits(this BigInteger[] array)
        {
            BigInteger[] a = { 0}, c = { };
            List<BigInteger> list = new List<BigInteger>();
            while(array.Length != 0)
            {
                a = array.Take(5).ToArray();
                var b = a.Where(x => x % 5 == 0).ToArray();
                array = array.Skip(5).ToArray();
                if(b.Length > 0)
                {
                    c = a.Where(x => x % 3 == 0).ToArray();
                    foreach (var f in c) list.Add(f);

                }
            }
            List<BigInteger> result = new List<BigInteger>();
            result = list.Where(x=> x!=0).Select(x => (BigInteger)x % 100).ToList();
            var resultStr = result.Select(x => x.ToString("00")).ToList();
            return resultStr;
        }

        public static int MaxSumSqrtDigits(this BigInteger[] array)
        {
            int res;
            var a = array.Select(x => new
            {
                value = x,
                sqrtSum = x.ToString().
            Where(y => int.TryParse(y.ToString(), out res)).
                Select(y => int.Parse(y.ToString())).
                Select(y => y * y).
                Sum(),

            }).ToList();
            int maxSum = a.Select(x => x.sqrtSum).Max();
            var value = a.Where(x => (int)x.sqrtSum == maxSum);
            foreach(var f in value)
            {
                return f.sqrtSum;
            }
            return 0;
        }
        public static double AverageCountOfZeros(this BigInteger[] array)
        {
            int res;
            var a = array.Select(x => new
            {
                value = x,
                countOfZeros = x.ToString().
            Where(y => int.TryParse(y.ToString(), out res)).
                Select(y => int.Parse(y.ToString())).
                Where(y => y == 0).
                Count(),

            }).ToList();
            double averageCount = a.Select(x => x.countOfZeros).Average();
            return averageCount;
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
            return (int)secondDigit;
        }
    }

    
}
