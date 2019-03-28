using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuitem = { "first",
                            "   second",
                            "   third"
                                
            };
            ConsoleKeyInfo key;
            int cur = 0;
            while (true)
            {
                
                Console.Clear();
                for (int i = 0; i < menuitem.Length; i++)
                {
                    if (cur == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(menuitem[i]);
                   
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        cur--;
                        break;
                    case ConsoleKey.DownArrow:
                        cur++;
                        break;
                }

                if (cur == menuitem.Length)
                {
                    cur = 0;
                }
                if (cur < 0)
                {
                    cur = menuitem.Length - 1; 
                }

                
            }
            
        }
    }
}
