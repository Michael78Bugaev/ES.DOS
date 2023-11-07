using ES_DOS.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ES_DOS.Screen
{
    public static class Welcome
    {
        public static void Show()
        {
            string[] Enterstart =
            {
                "  ##### #####           ",
                "  #   # #   #   #######        #     ###",
                "###   ###   #   #        # #   ###  #   #  #  ##",
                "# #   # #   #   #######  ## #  #    #####  ###  #",
                "# #   # #   #   #        #  #  #    #      #",
                "# ##### #####   #######  #  #   ##   ####  #",
                "##### #####     _______",
                "",
                "                #####  #                #",
                "               #       ###   ##   # ##  ###",
                "                ####   #    #  #  ##    #",
                "                    #  #    ####  #     #",
                "               #####    ##  #  #  #      ##",
                "        Enterstart company 1982-1988",
                "            ES-DOS v.1.00 Release\n\n"
            };
            Api.SetBGColor(ConsoleColor.DarkBlue);
            Api.SetFGColor(ConsoleColor.White);
            Console.Clear();
            foreach (string s in Enterstart)
            {
                Console.WriteLine(s);
                Thread.Sleep(20);
            }
            Thread.Sleep(2000);
            Api.ResetAll();
            Console.Clear();
        }
    }
}