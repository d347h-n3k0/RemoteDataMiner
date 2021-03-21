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
        public void LoadPlugin()
        {
            var DLL = Assembly.LoadFile();

            foreach (Type type in DLL.GetExportedTypes())
            {
                dynamic c = Activator.CreateInstance(type);
                c.Output(@"Hello");
            }
        }
    }
}
