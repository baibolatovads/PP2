using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Compare("f", "a"));
            //чтобы игнорировать регистр букв, в метод нужно как 3 аргумент передать true
            Console.WriteLine(String.Compare("ab", "Ab", true));
        }
    }
}
