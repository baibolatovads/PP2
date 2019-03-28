using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMinFromfileToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\User_PC\Documents\PP2\Phynal\SecondMinFromfileToFile\input.txt");
            string[] lines = line.Split(' ');
            int min = int.Parse(lines[0]);
            int min2 = int.Parse(lines[0]);
            for (int i = 0; i < lines.Length; i++)
            {
                int k = int.Parse(lines[i]);
                if (k <= min)
                {
                    min2 = min;
                    min = k;
                }
                else if (k >= min && k >= min2)
                {
                    min2 = k;
                    //break;
                }
            }
            File.WriteAllLines(@"C:\Users\User_PC\Documents\PP2\Phynal\SecondMinFromfileToFile\output.txt", new[] { min2.ToString() });
        }
    }
}
