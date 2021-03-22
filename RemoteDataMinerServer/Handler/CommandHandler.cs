using Neko.FancyLog;
using Neko.RemoteDataMinerServer.CustomData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.RemoteDataMinerServer.Handler
{
    /// <summary>
    /// Command Handler
    /// </summary>
    public class CommandHandler
    {

        /// <summary>
        /// Standart
        /// </summary>
        public CommandHandler()
        {
            
        }

        /// <summary>
        /// Standart
        /// </summary>
        /// <param name="statuses">Module Status list</param>
        public void CommandHandlerTest(List<Status> statuses)
        {
            WriteConsole.WriteModuleStatus(statuses);
            OnStatusPost(EventArgs.Empty);
        }

        /// <summary>
        /// Eventhandler for status post
        /// </summary>
        public event EventHandler StatusPost;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected virtual void OnStatusPost(EventArgs e)
        {
            EventHandler handler = StatusPost;
            handler?.Invoke(this, e);
        }

        
    }

    /// <summary>
    /// StatusPost EventArgs
    /// </summary>
    public class StatusPostEventArgs : EventArgs
    {

        /// <summary>
        /// Server Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Server Time
        /// </summary>
        public DateTime TimeReached { get; set; }
    }
}
