using ES_DOS.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;

namespace ES_DOS
{
    public static class FileEditor
    {
        public static List<string> list = new List<string>();
        static void print(string text)
        {
            Console.WriteLine(text);
        }
        static private string ReadLineOrEscape()
        {
            
            
            StringBuilder sb = new StringBuilder();

            
            string retString = "";

            while (true)
            {
                

            }
            
        }
        /// <summary>
        /// Запускает консольный файловый редактор.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public static void Init(string path, string name)
        {
            StringBuilder sb = new StringBuilder();
            path = path + name;
            if (File.Exists(path))
            {
                if (name.EndsWith(".ln"))
                {
                    Console.WriteLine("Cant open binary file.\n");
                }
                else if (name.EndsWith(".bin"))
                {
                    Console.WriteLine("Cant open binary file.");
                }
                else
                {
                    string retString = "";
                    int val = 22 - name.Length;
                    string separator = new string(' ', val);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();                                                                                 //
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("|   File Editor  // ES-DOS v.1.00 Release | ESC to exit | " + name + separator);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;

                    if (File.ReadAllLines(path).Length > 0)
                    {
                        string[] content = File.ReadAllLines(path);

                        foreach (var line in content)
                        {
                            Console.WriteLine(line);
                            list.Add(line);
                        }
                    }

                    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

                    while (true)
                    {
                        try
                        {
                            keyInfo = Console.ReadKey(true);
                            int index = 0;

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                Console.WriteLine();
                                retString += "\n";
                                list.Add(retString);
                            }
                            else if (keyInfo.Key == ConsoleKey.Spacebar)
                            {
                                Console.Write(' ');
                                retString += ' ';
                            }
                            else if (keyInfo.Key == ConsoleKey.Backspace)
                            {
                                if (Console.CursorLeft > 0)
                                {
                                    retString = retString.Remove(retString.Length - 1);
                                    Console.CursorLeft--;
                                    Console.Write(' ');
                                    Console.CursorLeft--;
                                }
                            }
                            // ---------
                            else if (keyInfo.Key == ConsoleKey.UpArrow)
                            {
                                if (Console.CursorTop > 0)
                                {
                                    Console.CursorTop--;
                                }
                                else
                                {
                                    Sys.PCSpeaker.Beep(Sys.Notes.G1);
                                }
                            }
                            else if (keyInfo.Key == ConsoleKey.DownArrow)
                            {
                                if (Console.CursorTop < 25)
                                {
                                    Console.CursorTop++;
                                }
                                else
                                {
                                    Sys.PCSpeaker.Beep(Sys.Notes.G1);
                                }
                            }
                            // ---------------
                            else if (keyInfo.Key == ConsoleKey.RightArrow)
                            {
                                if (Console.CursorLeft < 80)
                                {
                                    Console.CursorLeft++;
                                }
                            }
                            else if (keyInfo.Key == ConsoleKey.LeftArrow)
                            {
                                if (Console.CursorLeft > 0)
                                {
                                    Console.CursorLeft--;
                                }
                            }
                            else if (keyInfo.Key == ConsoleKey.Tab)
                            {
                                Console.Write("   ");
                                retString += "   ";
                            }

                            else if (keyInfo.KeyChar > 32 && keyInfo.KeyChar < 127)
                            {
                                Console.Write(keyInfo.KeyChar);
                                retString += keyInfo.KeyChar;
                                continue;
                            }
                            else if (keyInfo.Key == ConsoleKey.Escape)
                            {
                                list.Add(retString);
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Api.Message(ex.ToString(), 4);
                        }
                        
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Clear();
                    print("Saving...");
                    File.WriteAllLines(path, list.ToArray());
                    Console.Clear();
                    print("Successfuly saved!\n");
                }
            }
            else
            {
                Console.WriteLine($"This file ({name}) is not exists!\n");
            }
        }
    }
}