using NodeBlock.Engine;
using NodeBlock.Engine.API;
using NodeBlock.Engine.Interop;
using NodeBlock.Engine.Nodes;
using System;
using System.Numerics;
using NodeBlock.Engine.Encoding;
using System.IO;
using System.Runtime.InteropServices;
using NodeBlock.Engine.Storage.MariaDB;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace NodeBlock.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            
            NodeBlockExporter.ExportNodesSchema(Environment.GetEnvironmentVariable("node_schema_path"));
            try
            {
                // init graphs cost database updater
                GraphsContainer.InitConsumingGraphCosts();

                // init graphs that was live on last run
                if(Environment.GetEnvironmentVariable("relaunch_last_graph") == "true")
                {
                    GraphsContainer.InitActiveGraphs();
                }

                new InternalApi(new string[] { }, "0.0.0.0", 1337).InitApi();
            }
            catch (Exception error)
            {
                Console.WriteLine("Unable to init GraphLinq Engine API: {0}", error.Message);
            }

            Console.ReadLine();
        }
    }
}