using System;
using Microsoft.Extensions.Caching.Memory;
using Neko.FancyLog;
using Neko.RemoteDataMinerServer.Modules;
using Neko.RemoteDataMinerServer.Handler;
using Neko.RemoteDataMinerServer.CustomData;
using System.Collections.Generic;
using System.Threading;

namespace Neko.RemoteDataMinerServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteConsole.WriteColoredTop("Remote Data Miner", ConsoleColor.Green);

            List<Status> statuses = new List<Status> { new Status() { Module = "Main", Version = "0.1", Mode = Modes.runing } };
            IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            ConfigModule.Load(cache);
            ProjectModule.Load(cache);
            List<object> Plugins = PluginModule.LoadPlugin();

            try
            {
                Thread connectionServer = new Thread(() => ConnectionServer.threadStart(cache, Plugins));
                connectionServer.Start();
                statuses.Add(new Status() { Module = "ConnectionServer", Version = "0.1", Mode = Modes.runing });
            }
            catch(Exception e)
            {

            }

            CommandHandler commandHandler = new CommandHandler();
            commandHandler.StatusPost += commandHandler_Status;

            
            commandHandler.CommandHandlerTest(statuses);
             

            Console.ReadLine();
        }

        static void commandHandler_Status(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }
    }
}
