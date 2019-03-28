using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        int a, b;

        public Rectangle()
        {
            a = 0;
            b = 0;
        }

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        int Perimeter()
        {
            return 2 * (a + b);
        }

        int Area()
        {
            return a * b;
        }

        public void ReadInfo()
        {
            Console.WriteLine("Enter a:");
            this.a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b:");
            this.b = int.Parse(Console.ReadLine());
        }

        public void PrintInfo()
        {
            Console.WriteLine("{0}", Perimeter());
            Console.WriteLine("{0}", Area());
        }
    }
}