using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToCharArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Dariya";
            char[] array = s.ToCharArray();
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
