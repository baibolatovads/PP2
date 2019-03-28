using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clocksfromconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = { "       12        \n",
                                 "  11   ", "   1  \n",
                                 "10   ","        2 \n",
                                 "9      ","      3  \n",
                                 "  8    ","      4 \n",
                                  "  7   ","     5 \n",
                                "       6 \n       "
            };

           
            int cur = 0;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (cur + 1 == int.Parse(numbers[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(numbers[i]);
                }
                Thread.Sleep(1000);
                cur++;
                if (cur == 12)
                {
                    cur = 0;
                }

            }
        }


    }
}
