using System;
using Microsoft.Extensions.Caching.Memory;
using Neko.FancyLog;
using Neko.RemoteDataMinerServer.Modules;

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
            


            Console.ReadLine();
        }
    }
}
