using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int sum = 0;
            int d;
            for (int i = 0; i < ss.Length; i++)
            {
                d = int.Parse(ss[i]);
                for (int j = 0; j <= 20; j++)
                {
                    if (d == Math.Pow(2, j) - 1)
                    {
                        sum += d;
                    }
                }
            }
          
                    Console.WriteLine(sum);
        }
    }
}
