using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        int r;

        public Circle()
        {
            r = 0;
        }

        public Circle(int r)
        {
            this.r = r;
        }

        int Area()
        {
            return (Math.PI) * r * r;
        }
        int Diameter()
        {
            return 2 * r;
        }
        int Circumference()
        {
            return 2 * Math.PI * r;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Enter r:");
            this.r = int.Parse(Console.ReadLine());
        }

        public void ReadInfo()
        {
            Console.WriteLine("{0}", Area());
            Console.WriteLine("{0}", Diameter());
            Console.WriteLine("{0}", Circumference());

        }

    }
}
