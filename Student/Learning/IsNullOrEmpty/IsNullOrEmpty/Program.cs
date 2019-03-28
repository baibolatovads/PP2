using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsNullOrEmpty
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = null, s2 = "", s3 = "Hello", s4 = "\t";
            Console.WriteLine(String.IsNullOrWhiteSpace(s1));
            String.IsNullOrWhiteSpace(s2);
            String.IsNullOrWhiteSpace(s3);
            String.IsNullOrWhiteSpace(s4);
        }
    }
}
