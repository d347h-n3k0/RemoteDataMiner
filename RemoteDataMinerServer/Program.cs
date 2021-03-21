using System;
using Microsoft.Extensions.Caching.Memory;
using Neko.FancyLog;
using Neko.RemoteDataMinerServer.Modules;
using Neko.RemoteDataMinerServer.Handler;
using Neko.RemoteDataMinerServer.CustomData;
using System.Collections.Generic;

namespace Neko.RemoteDataMinerServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteConsole.WriteColoredTop("Remote Data Miner", ConsoleColor.Green);

            IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            ConfigModule.Load(cache);
            ProjectModule.Load(cache);

            CommandHandler commandHandler = new CommandHandler();
            commandHandler.StatusPost += commandHandler_Status;

            List<CustomData.Status> statuses = new List<CustomData.Status> { new CustomData.Status(){ Module = "Test", Version = "0.1", Mode = CustomData.Modes.runing} };
            commandHandler.CommandHandlerTest(statuses);


            Console.ReadLine();
        }

        static void commandHandler_Status(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }
    }
}
