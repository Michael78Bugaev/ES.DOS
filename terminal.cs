using System;
using System.IO;
using ES_DOS.API;

namespace ES_DOS
{
    public static class Terminal
    {
        /// <summary>
        /// Current Directory.
        /// </summary>
        public static string curPath = @"0:\";
        /// <summary>
        /// Start the main console.
        /// </summary>
        public static void Start()
        {
            #region root
            if (curPath == @"0:\")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Kernel.log + "-");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("root");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(":-");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("& ");
                Console.ForegroundColor= ConsoleColor.White;
            }
            else if (curPath != @"0:\")
            {
                string cur = curPath.Remove(0, 3);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Kernel.log + "-");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(@"root\"); 
                Console.ForegroundColor = ConsoleColor.Gray; 
                Console.Write(cur + ":-"); 
                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.Write("& "); 
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            string arg = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            if (arg.Contains(' ') == true)
            {
                string[] arr = arg.Split(' ', StringSplitOptions.TrimEntries);
                if (arr[0] == "cd")
                {
                    if (Directory.Exists(curPath + arr[1]))
                    {
                        curPath = curPath + arr[1] + @"\";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(arr[1] + ": This directory is not exists!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (arr[0] == "edit")
                {
                    FileEditor.Init(curPath, arr[1]);
                }
                else if (arr[0] == "md")
                {
                    if (!Directory.Exists(curPath + arr[1]))
                    {
                        Directory.CreateDirectory(curPath + arr[1]);
                    }
                    else
                    {
                        Api.Message($"Directory {arr[1]} is already exists!", 3);
                    }
                }
                else if (arr[0] == "dd")
                {
                    if (Directory.Exists(curPath + arr[1]))
                    {
                        Directory.Delete(curPath + arr[1]);
                    }
                    else
                    {
                        Api.Message("Can't found directory: " + arr[1], 3);
                    }
                }
                else if (arr[0] == "mf")
                {
                    if (!File.Exists(curPath + arr[1]))
                    {
                        File.Create(curPath + arr[1]);
                    }
                    else
                    {
                        Api.Message($"File {arr[1]} is already exists!", 3);
                    }
                }
                else if (arr[0] == "df")
                {
                    if (File.Exists(curPath + arr[1]))
                    {
                        File.Delete(curPath + arr[1]);
                    }
                    else
                    {
                        Api.Message($"Can't find file '{arr[1]}'.", 3);
                    }
                }
                else if (arr[0] == "easm")
                {
                    Api.Message("EASM will be ready in later versions of ES-DOS. \n        Compilation is not possible.", 1);
                }
                else if (arr[0] == "dotc")
                {
                    Api.Message("DOTC compiler will be ready in later versions of ES-DOS. \n        Compilation is not possible.", 1);
                }
                else if (arr[0] == "help")
                {
                    switch (arr[1])
                    {
                        case "edit":
                            Console.WriteLine("The \"edit\" command is intended for editing text files. \nUsage example: &edit main.asm\n");
                            break;
                        case "cd":
                            Console.WriteLine("The \"cd\" command is intended to change directories, depending on the \nexistence of the directory itself. Usage example: &cd system16\n");
                            break;
                        case "mf":
                            Console.WriteLine("The \"mf\" command is intended to creating files. Usage example: &mf document.txt\n");
                            break;
                        case "df":
                            Console.WriteLine("The \"df\" command is intended to delete a specific file, \ndepending on its existence. Usage example: &df document.txt\n");
                            break;
                        case "md":
                            Console.WriteLine("The \"md\" command is intended to create a particular directory. Usage example: &md UserFolder\n");
                            break;
                        case "dd":
                            Console.WriteLine("The \"dd\" command is intended to delete a particular directory, \ndepending on its existence. Usage example: &dd UserFolder\n");
                            break;
                        case "easm":
                            Console.WriteLine("EASM stands for Enterstart Assembler.\nThis compiler will be available in later versions of ES-DOS.\n");
                            break;
                        case "dotc":
                            Console.WriteLine("DotC is a C language interpreter created by Enterstart.\nThis interpreter will be available in later versions of ES-DOS.\n");
                            break;
                        case "cls":
                            Console.WriteLine("The \"cls\" command in intended to clear screen. This command does not require any arguments.\n");
                            break;
                        default:
                            Console.WriteLine("Print 'help' for the list of commands.\n");
                            break;
                    }
                }
                else
                {
                    Api.Message("Unknown command: " + arr[0], 3);                   
                }
                
            }
            else if (arg.Contains(' ') == false)
            {
                if (arg == "root")
                {
                    curPath = @"0:\";
                }
                else if (String.IsNullOrWhiteSpace(arg)){}
                else if (arg == "easm")
                {
                    Api.Message("EASM will be ready in later versions of ES-DOS. \n        Compilation is not possible.", 1);
                }
                else if (arg == "dotc")
                {
                    Api.Message("DOTC compiler will be ready in later versions of ES-DOS. \n        Compilation is not possible.", 1);
                }
                else if (arg.EndsWith(".txt"))
                {
                    if (File.Exists(curPath + arg))
                    {
                        if (File.ReadAllText(curPath + arg).Length > 0)
                        {
                            Console.WriteLine("Show content of " + arg + " file\n");
                            string[] content = File.ReadAllLines(curPath + arg);
                            foreach (string line in content)
                            {
                                Console.WriteLine(line);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("File is empty. Nothing to read.");
                        }
                    }
                    else
                    {
                        Api.Message("File not found.", 2);
                    }
                    

                }
                else if (arg.EndsWith(".bin"))
                {
                    try
                    {
                        if (File.Exists(curPath + arg))
                        {
                            Api.Message("This file is binary! Reading...", 2);
                            if (File.ReadAllBytes(curPath + arg).Length > 0)
                            {
                                byte[] content = File.ReadAllBytes(curPath + arg);

                                foreach (byte b in content)
                                {
                                    Console.Write(b + ' ');
                                }
                            }
                            else
                            {
                                Api.Message("Binary file is empty. Nothing to read.", 3);
                            }
                        }
                        else
                        {
                            Api.Message("File not found.", 3);
                        }
                    }
                    catch (Exception ex)
                    {
                        Api.Message(ex.ToString(), 4);
                    }
                }
                else if (arg.EndsWith(".asm"))
                {
                    Api.Message("EASM will be ready in later versions of ES-DOS. \n        Compilation is not possible.", 1);
                }
                else if (arg == "ver")
                {
                    Console.WriteLine("ES-DOS v.1.00 Release by Enterstart (ES) company.\n            Run on VMware!\n");
                }
                else if (arg == "help")
                {
                    string[] help =
                {
                "----------------------------\nhelp         show this menu",
                "cls          clear screen",
                "edit [file]  edit document",
                "mf [file]    make file",
                "df [file]    delete file",
                "md [dir]     make directory",
                "dd [dir]     delete directory",
                "dir          content of the current directory",
                "cd [dir]     change directory",
                "freespace    show free space in kbytes",
                "off          power off",
                "reboot       reboot computer",
                "filesystem   show type of the filesystem\n--------------------------------\n"
            };
                    foreach (string s in help)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (arg == "cls")
                {
                    Console.Clear();
                    Console.WriteLine();
                }
                else if (arg == "up")
                {
                    if (curPath == @"0:\")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cant go up than root folder!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        curPath = Directory.GetParent(curPath).FullName + @"\";
                    }
                }
                else if (arg == "dir")
                {
                    var files_list = Directory.GetFiles(curPath);
                    var directory_list = Directory.GetDirectories(curPath);
                    int dir = 0;
                    int files = 0;
                    Console.WriteLine("\nList of " + curPath + " directory.\n Filename        Size           Description");
                    if (Directory.GetDirectories(curPath).Length < 1 && Directory.GetFiles(curPath).Length < 1)
                    {
                        Console.WriteLine("    <EMPTY>");
                    }
                    foreach (var file in files_list)
                    {
                        if (file.EndsWith(".c"))
                        {
                            FileInfo Cinf = new FileInfo(curPath + file);
                            Api.SetFGColor(ConsoleColor.Cyan);
                            Console.Write($" {file}    ");
                            Api.SetFGColor(ConsoleColor.White);
                            Console.WriteLine(Cinf.Length + " bytes    C programming language file.");
                            Api.ResetFGColor();
                            files++;
                        }
                        else if (file.EndsWith(".asm"))
                        {
                            FileInfo asminf = new FileInfo(curPath + file);
                            Api.SetFGColor(ConsoleColor.Red);
                            Console.Write($" {file}    ");
                            Api.SetFGColor(ConsoleColor.White);
                            Console.WriteLine(asminf.Length + " bytes    Assembly language file.");
                            Api.ResetFGColor();
                            files++;
                        }
                        else
                        {
                            FileInfo fileinf = new FileInfo(curPath + file);
                            Api.SetFGColor(ConsoleColor.DarkCyan);
                            Console.Write($" {file}    ");
                            Api.SetFGColor(ConsoleColor.White);
                            Console.WriteLine(fileinf.Length + " bytes");
                            Api.ResetFGColor();
                            files++;
                        }
                        
                    }
                    foreach (var directory in directory_list)
                    {
                        Api.SetFGColor(ConsoleColor.Yellow);
                        Console.WriteLine($" {directory}    ");
                        Api.ResetFGColor();
                        dir++;
                    }
                    Console.WriteLine($"Total files: {files}  Total directories: {dir}\n");
                }
                else if (arg == "freespace")
                {
                    var available_space = Kernel.fs.GetAvailableFreeSpace(@"0:\");
                    Console.WriteLine("Available free space: " + available_space / 1024 + " kbytes.\n");
                }
                else if (arg == "filesystem")
                {
                    var fs_type = Kernel.fs.GetFileSystemType(@"0:\");
                    Console.WriteLine("File System Type: " + fs_type + "\n");
                }
                else if (arg == "off")
                {
                    Cosmos.System.Power.Shutdown();
                }
                else if (arg == "reboot")
                {
                    Cosmos.System.Power.Reboot();
                }
                else if (arg == "cd")
                {
                    Console.WriteLine(curPath);
                }
                else if (arg == "md")
                {
                    Console.WriteLine("Usage: md test_dir\n");
                }
                else if (arg == "dd")
                {
                    Console.WriteLine("Usage: dd test_dir\n");
                }
                else if (arg == "mf")
                {
                    Console.WriteLine("Usage: mf file.txt (*.asm,*.c,*.bin etc.)\n");
                }
                else if (arg == "df")
                {
                    Console.WriteLine("Usage: df test.txt (*.asm, *.c, *.bin etc.)\n");
                }
                else if (arg == "edit")
                {
                    Console.WriteLine("Usage: edit file_name.txt (*.asm, *.bin, *.c)\n");
                }
                else
                {
                    Api.Message($"Unknown command: {arg}.", 3);
                }
            }
            
        }
    }
}
