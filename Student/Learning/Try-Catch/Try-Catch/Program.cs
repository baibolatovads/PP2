using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine("Enter a number");
            try
            {
                int a = int.Parse(Console.ReadLine());
                s = "You've entered number " + a;
            }
            catch (FormatException)
            {
                s = "You've entered wrong format";
            }
            Console.WriteLine(s);
        }
    }
}
