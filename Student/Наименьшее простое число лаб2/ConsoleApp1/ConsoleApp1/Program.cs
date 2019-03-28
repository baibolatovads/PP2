using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter your list of numbers in a row: ");
            char[] splitter = { ' ', '.' };
            string line = File.ReadLines(path: @"C:\Users\User_PC\Documents\PP2\Student\Week 2\\Minmax.txt").Select(s => Convert.ToDecimal(s, CultureInfo.InvariantCulture)).ToList();
            string[] numbers = line.Split(splitter);
            int n = numbers.Length;
            var primes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int t = int.Parse(numbers[i]);
                if (Class1.IsPrime(t))
                {
                    primes.Add(t);
                }
            }
            Console.WriteAllText(@"C:\Users\User_PC\Documents\PP2\Student\Week 2\\output.txt",primes.Min());
        }
    }
}