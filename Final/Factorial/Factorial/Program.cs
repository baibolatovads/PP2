using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int res;

            n = int.Parse(Console.ReadLine());
            res = 1;
            for (int i = 1; i <= n; i++)
            {
                res = res * i;
            }

            Console.WriteLine(res);


        }
    }
}
