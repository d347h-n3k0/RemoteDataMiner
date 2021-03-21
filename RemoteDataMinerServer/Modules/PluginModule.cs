using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neko.RemoteDataMinerServer.Modules
{
    /// <summary>
    /// Plugin Handler module
    /// </summary>
    public class PluginModule
    {
        /// <summary>
        /// Loads an Plugin
        /// </summary>
        public static void LoadPlugin()
        {
            var DLL = Assembly.LoadFile(@"C:\Users\janni\source\repos\RemoteDataMiner\TestPlugin\bin\Debug\net5.0\TestPlugin.dll");

            foreach (Type type in DLL.GetExportedTypes())
            {
                dynamic c = Activator.CreateInstance(type);
                c.Init(@"Hello");
            }
        }
    }
}
