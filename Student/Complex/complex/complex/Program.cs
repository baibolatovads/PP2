using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Complex x = new Complex(1, 3);
            Complex y = new Complex(7, 24);
            Complex result = x + y;
            Console.WriteLine(result);
        }
    }
}
