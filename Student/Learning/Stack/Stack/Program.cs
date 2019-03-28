using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackBasedIteration
    {
            static void Main(string[] args)
            {
                TraverseTree(args[0]);
            }

            public static void TraverseTree(string root)
            {
                Stack<string> dirs = new Stack<string>(20);

                if (!Directory.Exists(root))
                {
                    throw new ArgumentException();
                }
                dirs.Push(root);

                while (dirs.Count > 0)
                {
                    string currentDir = dirs.Pop();
                    string[] subdirs;
                    try
                    {
                        subdirs = Directory.GetDirectories(currentDir);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    string[] files = null;
                    try
                    {
                        files = Directory.GetFiles(currentDir);
                    }

                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    foreach (string file in files)
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(file);
                            Console.WriteLine("{0} : {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }
                    foreach (string str in subdirs)
                    {
                        dirs.Push(str);
                    }
                }
            }
        }
    }
