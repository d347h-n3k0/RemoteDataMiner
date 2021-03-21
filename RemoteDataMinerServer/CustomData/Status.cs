namespace Neko.RemoteDataMinerServer.CustomData
{
    /// <summary>
    /// Programm Status
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Modules name
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// Module Version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Programm Statusmode
        /// </summary>
        public Modes Mode { get; set; }
    }

    /// <summary>
    /// Programm modes
    /// </summary>
    public enum Modes
    {
        /// <summary>
        /// Programm not running
        /// </summary>
        stopped = 0,
        /// <summary>
        /// Programm running
        /// </summary>
        runing = 1,
        /// <summary>
        /// Programm threw an warning
        /// </summary>
        warning = 2,
        /// <summary>
        /// Programm ran into an error
        /// </summary>
        error = 3,
        /// <summary>
        /// Programm has crashed
        /// </summary>
        crash = 4
    }
}
