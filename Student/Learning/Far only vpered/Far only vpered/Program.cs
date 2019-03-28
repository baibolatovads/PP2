using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far_only_vpered
{
    class Program
    {
        static void PrintState(int index, FileSystemInfo[] arr)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(arr[i].Name);
            }
        }


            static void Main(string[] args)
        {
                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\User_PC\Documents\PP2\ConsoleApp1");
                    FileSystemInfo[] arr = di.GetFileSystemInfos();
                    int index = 0;
                    bool quit = false;

                    while (!quit)
                    {
                        PrintState(index, arr);

                        ConsoleKeyInfo pressedkey = Console.ReadKey();

                        switch (pressedkey.Key)
                        {
                            case ConsoleKey.UpArrow:
                                index--;
                                if (index < 0) index = arr.Length - 1;
                                break;
                            case ConsoleKey.DownArrow:
                                index = (index + 1) % arr.Length;
                                break;
                            case ConsoleKey.Enter:
                                if (arr[index].GetType() == typeof(DirectoryInfo))
                                {
                                    DirectoryInfo d = arr[index] as DirectoryInfo;
                                    arr = d.GetFileSystemInfos();
                                    index = 0;
                                }
                                break;
                            case ConsoleKey.Escape:
                                quit = true;
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
        }
    