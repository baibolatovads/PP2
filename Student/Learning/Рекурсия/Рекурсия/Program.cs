using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рекурсия
{
    public class RecursiveFileResearch
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        class Program
        {
            static void Main(string[] args)
            {
                string[] drives = System.Environment.GetLogicalDrives();
                foreach (string dr in drives)
                {
                    DriveInfo di = new DriveInfo(dr);

                    if (!di.IsReady)
                    {
                        Console.WriteLine("The drive {0} could not be read!", di.Name);
                        continue;
                    }
                    DirectoryInfo rootdir = di.RootDirectory;
                    WalkDirectoryTree(rootdir);
                }
                Console.WriteLine("Files with rectricted access:");
                foreach (string s in log)
                {
                    Console.WriteLine(s);
                }
            }
            static void WalkDirectoryTree(DirectoryInfo root)
            {
                FileInfo[] files = null;
                DirectoryInfo[] subdirs = null;

                //processing all the files directly under this folder
                try
                {
                    files = root.GetFiles("*.*");
                }
                catch (UnauthorizedAccessException e)
                {
                    log.Add(e.Message);
                }

                if (files != null)
                {
                    foreach (FileInfo fi in files)
                    {
                        Console.WriteLine(fi.FullName);
                    }

                    subdirs = root.GetDirectories();

                    foreach (DirectoryInfo dirInfo in subdirs)
                    {
                        WalkDirectoryTree(dirInfo);
                    }
                }
            }
        }
    }

}