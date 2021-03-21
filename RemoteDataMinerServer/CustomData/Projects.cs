using System.Collections.Generic;

namespace Neko.RemoteDataMinerServer.CustomData
{
    /// <summary>
    /// Stores all project types
    /// </summary>
    public class Projects
    {
        /// <summary>
        /// Stores HTML projects
        /// </summary>
        public List<ProjectLayout> Html { get; set; }

        /// <summary>
        /// Stores Java projects
        /// </summary>
        public List<ProjectLayout> Java { get; set; }

        /// <summary>
        /// Stores CSHAR projects
        /// </summary>
        public List<ProjectLayout> CSHARP { get; set; }

        /// <summary>
        /// Stores Python projects
        /// </summary>
        public List<ProjectLayout> Python { get; set; }

        /// <summary>
        /// Stores PHP projects
        /// </summary>
        public List<ProjectLayout> PHP { get; set; }
    }

    /// <summary>
    /// Project layout
    /// </summary>
    public class ProjectLayout
    {
        /// <summary>
        /// Stores the project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Stores the project path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Stores the project version
        /// </summary>
        public string Version { get; set; }
    }
}
