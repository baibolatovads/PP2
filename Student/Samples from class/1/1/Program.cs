using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream files = new FileStream(@"C:\Users\User_PC\Documents\PP2\Student\Samples from class\\onlyone.txt", FileMode.OpenOrCreate, FileAccess.Read);

            var numbers = files.Select(s => Convert.ToDecimal(s, CultureInfo.InvariantCulture)).ToList();
            var max = numbers.Max();
            var min = numbers.Min();
            Console.WriteLine(min.ToString() + " / " + max.ToString());

        }
    }
}
