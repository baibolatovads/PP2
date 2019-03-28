using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatKBTU
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\User_PC\Documents\PP2\Final\birnarseneponyatnyi");
            FileSystemInfo[] fs = directory.GetFiles();
            for (int i = 0; i < fs.Length; i++)
            {
                if (fs[i].Name.Contains(".txt"))
                {
                    string line = File.ReadAllText(fs[i].FullName);
                    if (line.Contains("KBTU"))
                    {
                        Console.WriteLine(fs[i].Name);
                    }
                }
            }
           
        }
    }
}
