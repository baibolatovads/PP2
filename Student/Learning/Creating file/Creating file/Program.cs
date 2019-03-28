using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_file
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"C:\Users\User_PC\Documents\\new_file.txt", FileMode.Open);
            StreamWriter writer = new StreamWriter(file);
            writer.Write("Hello World!");
            writer.Close();

        }
    }
}
