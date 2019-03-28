using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrimebyAibek
{
    class Program
    {
        /// <summary>
        /// Function that check if this number prim eor not
        /// </summary>
        /// <param name="n">Possible number that you test</param>
        /// <returns>Numbers that are prime</returns>
       
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            char[] splitter = { ' ', '.' };
            string line = Console.ReadLine();
            string[] numbers = line.Split(splitter);
            int n = numbers.Length;
            var Primes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int t = int.Parse(numbers[i]);
                if (IsPrime(t))
                {
                    Primes.Add(t);
                }
               
            }

            Primes.Sort();

            foreach(var i in Primes)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}
