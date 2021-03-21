namespace Neko.RemoteDataMinerServer.CustomData
{
    /// <summary>
    /// Config Data structure
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// Server Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Host Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Logging level
        /// </summary>
        public LoggingLevel Logging { get; set; }
    }
}
