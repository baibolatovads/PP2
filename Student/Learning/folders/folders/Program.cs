using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folders
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo di = new DriveInfo(@"C:\");
            Console.WriteLine(di.TotalFreeSpace);
            Console.WriteLine(di.VolumeLabel);


            DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            foreach (FileInfo fi in fileNames)
            {
                Console.WriteLine("{0} : {1} : {2}", fi.Name, fi.LastAccessTime, fi.Length);
            }

            DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach(DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }

        }
    }
}
