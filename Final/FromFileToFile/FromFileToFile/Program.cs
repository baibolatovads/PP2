using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FromFileToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C: \Users\User_PC\Documents\PP2\Phynal\FromFileToFile\input.txt");
            string[] numbers = line.Split(' ');
            int max = -1;
            int max2 = -1;
            
           
            for (int i = 0; i < numbers.Length; i++)
            {
                int k = int.Parse(numbers[i]);
                if (k >= max)
                {
                   
                    max2 = max;
                    max = k;

                }

                else if (k <= max && k >= max2)
                {
                    max2 = k;
                }
                
            }
            string[] s = new string[1] { max2.ToString() };

            File.WriteAllLines(@"C:\Users\User_PC\Documents\PP2\Phynal\FromFileToFile\output.txt", new []{ max2.ToString() });

        }
    }
}
