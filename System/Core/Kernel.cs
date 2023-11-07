using System;
using Sys = Cosmos.System;
using System.Threading;
using ES_DOS.Screen;
using Cosmos.System.FileSystem.VFS;
using System.Collections.Generic;
using Cosmos.System.FileSystem;

namespace ES_DOS
{
    public class Kernel : Sys.Kernel
    {
        public static Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static string log;
        public static string pass;
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("Starting ES-DOS...");
            Thread.Sleep(3000);

            //LoginManager.CheckAccount();  Under Construction...
            Welcome.Show();
        }

        protected override void Run()
        {
            Terminal.Start();
        }
    }
}
