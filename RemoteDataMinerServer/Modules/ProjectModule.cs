using Microsoft.Extensions.Caching.Memory;
using Neko.FancyLog;
using Neko.RemoteDataMinerServer.CustomData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.RemoteDataMinerServer.Modules
{
    /// <summary>
    /// Handel project lists
    /// </summary>
    public class ProjectModule
    {
        /// <summary>
        /// Loads saved projects
        /// </summary>
        /// <param name="cache"></param>
        public static void Load(IMemoryCache cache)
        {
            try
            {
                bool missing = false;
                var currentDir = Directory.GetCurrentDirectory(); //Current operating directory
                Projects projects = new Projects();

                try
                {
                    if (File.Exists(currentDir + "/projects/HtmlProjects.json"))
                    {
                        WriteConsole.WriteInfo("Loading HTML Projects file!");
                        projects.Html = JsonConvert.DeserializeObject<List<ProjectLayout>>(File.ReadAllText(currentDir + "/projects/HtmlProjects.json")); //Read config file and create config object
                        WriteConsole.WriteSuccess("Successfully red HTML projects!");
                    }
                    else
                    {
                        WriteConsole.WriteWarning("Found no HTML Project file!");
                        missing = true;
                    }
                }
                catch(Exception e)
                {
                    WriteConsole.WriteError("Could not load HTML projects", e);
                }

                try
                {
                    if (File.Exists(currentDir + "/projects/JavaProjects.json"))
                    {
                        WriteConsole.WriteInfo("Loading JAVA Projects file!");
                        projects.Java = JsonConvert.DeserializeObject<List<ProjectLayout>>(File.ReadAllText(currentDir + "/projects/JavaProjects.json")); //Read config file and create config object
                        WriteConsole.WriteSuccess("Successfully red JAVA projects!");
                    }
                    else
                    {
                        WriteConsole.WriteWarning("Found no JAVA Project file!");
                        if (!missing)
                        {
                            missing = true;
                        }
                    }
                }
                catch(Exception e)
                {
                    WriteConsole.WriteError("Could not load JAVA projects", e);
                }

                try
                {
                    if(File.Exists(currentDir + "/projects/CSharpProjects.json"))
                    {
                        WriteConsole.WriteInfo("Loading CSHARP projects file!");
                        projects.CSHARP = JsonConvert.DeserializeObject<List<ProjectLayout>>(File.ReadAllText(currentDir + "/projects/CSharpProjects.json")); //Read config file and create config object
                        WriteConsole.WriteSuccess("Successfully red CSHARP projects");
                    }
                    else
                    {
                        WriteConsole.WriteWarning("Found no CSHARP Project file!");
                        if (!missing)
                        {
                            missing = true;
                        }
                    }
                }
                catch(Exception e)
                {
                    WriteConsole.WriteError("Could not load CSHARP projects", e);
                }

                try
                {
                    if(File.Exists(currentDir + "/projects/PythonProjects.json"))
                    {
                        WriteConsole.WriteInfo("Loading Python projects file!");
                        projects.Python = JsonConvert.DeserializeObject<List<ProjectLayout>>(File.ReadAllText(currentDir + "/projects/PythonProjects.json")); //Read config file and create config object
                        WriteConsole.WriteSuccess("Successfully red Python projects");
                    }
                    else
                    {
                        WriteConsole.WriteWarning("Found no Python projects file");
                        if (!missing)
                        {
                            missing = true;
                        }
                    }
                }
                catch(Exception e)
                {
                    WriteConsole.WriteError("Could not load Python projects", e);
                }

                try
                {
                    if (File.Exists(currentDir + "/projects/PHPProjects.json"))
                    {
                        WriteConsole.WriteInfo("Loading PHP projects file!");
                        projects.Python = JsonConvert.DeserializeObject<List<ProjectLayout>>(File.ReadAllText(currentDir + "/projects/PHPProjects.json")); //Read config file and create config object
                        WriteConsole.WriteSuccess("Successfully red PHP projects");
                    }
                    else
                    {
                        WriteConsole.WriteWarning("Found no PHP projects file");
                        if (!missing)
                        {
                            missing = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    WriteConsole.WriteError("Could not load PHP projects", e);
                }

                if (!missing)
                {
                    WriteConsole.WriteInfo("Saving projects to ram cache....");
                    cache.Set("HTML", projects.Html);
                    cache.Set("PHP", projects.PHP);
                    cache.Set("JAVA", projects.Java);
                    cache.Set("Python", projects.Python);
                    cache.Set("CSHARP", projects.CSHARP);
                    WriteConsole.WriteSuccess("Saved projects successfully in ram cache");
                }
                else
                {
                    Create();
                    Load(cache);
                }
            }
            catch (Exception e)
            {
                WriteConsole.WriteError("Could not load the projects!", e);
            }
        }

        /// <summary>
        /// Creates project lists
        /// </summary>
        public static void Create()
        {
            var currentDir = Directory.GetCurrentDirectory(); //Current operating directory
            Projects projects = new Projects();

            try
            {
                if(!Directory.Exists(currentDir + "/projects/"))
                {
                    WriteConsole.WriteWarning("Projects directory not found!");
                    WriteConsole.WriteInfo("Creating new projects directory....");
                    Directory.CreateDirectory(currentDir + "/projects/");
                    WriteConsole.WriteSuccess("Successfully created projects directory");
                }

                if (!File.Exists(currentDir + "/projects/PHPProjects.json"))
                {

                    using (StreamWriter file = File.CreateText(currentDir + "/projects/PHPProjects.json"))
                    {
                        WriteConsole.WriteInfo("Creating PHP projects file....");
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, projects.PHP);
                        WriteConsole.WriteSuccess("Successfully created PHP projects file!");
                    }
                }

                if (!File.Exists(currentDir + "/projects/HtmlProjects.json"))
                {
                    using (StreamWriter file = File.CreateText(currentDir + "/projects/HtmlProjects.json"))
                    {
                        WriteConsole.WriteInfo("Creating HTML projects file....");
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, projects.Html);
                        WriteConsole.WriteSuccess("Successfully created HTML projects file!");
                    }
                }

                if (!File.Exists(currentDir + "/projects/JavaProjects.json"))
                {
                    using (StreamWriter file = File.CreateText(currentDir + "/projects/JavaProjects.json"))
                    {
                        WriteConsole.WriteInfo("Creating Java projects file....");
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, projects.Java);
                        WriteConsole.WriteSuccess("Successfully created Java projects file!");
                    }
                }

                if (!File.Exists(currentDir + "/projects/CSharpProjects.json"))
                {
                    using (StreamWriter file = File.CreateText(currentDir + "/projects/CSharpProjects.json"))
                    {
                        WriteConsole.WriteInfo("Creating CSHARP projects file....");
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, projects.CSHARP);
                        WriteConsole.WriteSuccess("Successfully created CSHARP projects file!");
                    }
                }

                if (!File.Exists(currentDir + "/projects/PythonProjects.json"))
                {
                    using (StreamWriter file = File.CreateText(currentDir + "/projects/PythonProjects.json"))
                    {
                        WriteConsole.WriteInfo("Creating Python projects file....");
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, projects.Python);
                        WriteConsole.WriteSuccess("Successfully created Python projects file!"); 
                    }
                }
            }
            catch (Exception e)
            {
                WriteConsole.WriteError("Could not create Project files", e);
            }
        }
    }
}
