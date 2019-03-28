using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rename_directory
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"C:\Users\User_PC\Documents\PP2\Student\Learning\rename directory\\1");
            Directory.Move(@"C:\Users\User_PC\Documents\PP2\Student\Learning\rename directory\\1", @"C:\Users\User_PC\Documents\PP2\Student\Learning\rename directory\\2");
        }
    }
}
