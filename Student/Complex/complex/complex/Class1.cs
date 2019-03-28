using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex
{
    public class Complex
    {
        public int a;
        public int b;

        public Complex()
        {
        } 

        public Complex(int _a, int _b)
        {
            a = _a;
            b = _b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex p = new Complex();
            p.a = c1.a * c2.b + c2.a * c1.b;
            p.b = c1.b + c2.b;
            return p;
        }
        public override string ToString()
        {
            return  a + "/" + b;
        }

    }
}
