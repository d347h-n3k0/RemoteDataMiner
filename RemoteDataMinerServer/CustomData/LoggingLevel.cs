namespace Neko.RemoteDataMinerServer.CustomData
{
    /// <summary>
    /// Logging Levels
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// None logging
        /// </summary>
        none = 0,
        /// <summary>
        /// Loggs only crashes
        /// </summary>
        crash = 1,
        /// <summary>
        /// Loggs errors and crashes
        /// </summary>
        error = 2,
        /// <summary>
        /// Loggs errors, crashes and commands
        /// </summary>
        commands = 3,
        /// <summary>
        /// Loggs everything
        /// </summary>
        all = 4
    }
}
