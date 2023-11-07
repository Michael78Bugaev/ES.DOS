using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ES_DOS.API;

namespace ES_DOS.System.Parts
{
    public static class LoginManager
    {
        public static void CheckAccount()
        {
            bool IsLoginOrReg = false;
            Console.Clear();

            if (!File.Exists(@"0:\login.ln"))
            {
                File.Create(@"0:\login.ln");
                Console.WriteLine("\nYou are not registred. Please, register to continue:");
                Console.Write("\nEnter login: ");
                string login = Console.ReadLine();
                Console.Write("\nEnter password: ");
                Console.ForegroundColor = ConsoleColor.Black;
                string password = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please, wait...");
                string[] logincontent =
                {
                    "login=" + login,
                    "password=" + password
                };
                File.WriteAllLines(@"0:\login.ln", logincontent);
                IsLoginOrReg = true;
                Cosmos.System.Power.Reboot();
            }
            while (IsLoginOrReg == false)
            {
                try
                {
                    Console.Write("Enter login: ");
                    string login = Console.ReadLine();
                    Console.Write("Enter password: ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    string password = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please, wait...");
                    string[] retlogin = File.ReadAllLines(@"0:\login.ln");
                    Kernel.log = retlogin[0].Remove(0, 6);
                    Kernel.pass = retlogin[1].Remove(0, 9);
                    if (login == Kernel.log && password == Kernel.pass)
                    {
                        IsLoginOrReg = true;
                        Console.Clear();
                        Screen.Welcome.Show();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Uncorrect login, or password. Try again.\n");
                    }
                }
                catch (Exception ex)
                {
                    Api.Message(ex.ToString(), 4);
                }              
            }
        }
    }
}
