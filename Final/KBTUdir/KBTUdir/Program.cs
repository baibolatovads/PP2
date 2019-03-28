using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBTUdir
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\User_PC\Desktop\IELTS essays");
            FileSystemInfo[] fileSystemInfos = directory.GetFiles();

            for (int i = 0; i < fileSystemInfos.Length; i++)
            {
                if (fileSystemInfos[i].Name.Contains(".txt"))
                {
                    string text = File.ReadAllText(fileSystemInfos[i].FullName);
                    if (text.Contains("KBTU"))
                    {
                        Console.WriteLine(fileSystemInfos[i].Name);
                    }
                }
            }
        }
    }
}
