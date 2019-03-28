using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Светофор
{
    class Program
    {
        static void Main(string[] args)
        {
            string stars =  "*****\n*****\n*****\n*****\n";
                           


            
            int cur = 0;
            ConsoleColor color = ConsoleColor.Red;
            while (true)
                
            {
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    if (cur == i)
                    {
                        Console.ForegroundColor = color;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.WriteLine(stars);
                    
                }

                Thread.Sleep(1000);
                cur++;
                if (cur == 3)
                {
                    cur = 0;
                }
                if(cur == 0)
                {
                    color = ConsoleColor.Red;
                }
                if(cur == 1)
                {
                    color = ConsoleColor.Yellow;
                }
                if (cur == 2)
                {
                    color = ConsoleColor.Green;
                }
            }
        }
    }
}
