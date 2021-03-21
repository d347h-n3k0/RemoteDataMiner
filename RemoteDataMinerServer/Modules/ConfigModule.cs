using Microsoft.Extensions.Caching.Memory;
using System.IO;
using System;
using Neko.RemoteDataMinerServer.CustomData;
using Newtonsoft.Json;
using Neko.FancyLog;

namespace Neko.RemoteDataMinerServer.Modules
{
    /// <summary>
    /// Handles config using
    /// </summary>
    public class ConfigModule
    {
        /// <summary>
        /// Loads the config
        /// </summary>
        /// <param name="cache">Used cache</param>
        public static void Load(IMemoryCache cache)
        {
            try
            {

                var currentDir = Directory.GetCurrentDirectory(); //Current operating directory

                if (File.Exists(currentDir + "/config.json"))
                {
                    WriteConsole.WriteInfo("Found config file!");
                    ConfigData Config = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(currentDir + "/config.json")); //Read config file and create config object
                    WriteConsole.WriteSuccess("Successfully red config!");
                    WriteConsole.WriteInfo("Writing config to ram....");

                    cache.Set("Version", Config.Version);
                    cache.Set("Port", Config.Port);
                    cache.Set("Logging", Config.Logging);

                    WriteConsole.WriteSuccess("Config successfully loaded!");
                }
                else
                {
                    WriteConsole.WriteWarning("Found no config file!");
                    Create();
                    Load(cache);
                }
            }
            catch(Exception e)
            {
                WriteConsole.WriteError("Could not load the config!", e);
            }
        }

        /// <summary>
        /// Creates standart config
        /// </summary>
        public static void Create()
        {            
            var currentDir = Directory.GetCurrentDirectory(); //Current operating directory
            if (!File.Exists(currentDir + "/config.json"))
            {
                WriteConsole.WriteInfo("Creating new config file....");
                ConfigData config = new ConfigData() { 
                    Version = "0.1", 
                    Port = 666, 
                    Logging = LoggingLevel.commands 
                };
                //var json = JsonConvert.SerializeObject(config);
                //File.Create(currentDir + "/config.json");
                using (StreamWriter file = File.CreateText(currentDir + "/config.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, config);
                }
            }
        }
    }
}
