using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            string scriptPath = @".\simple_example.ps1";
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            Command myCommand = new Command(scriptPath);
            CommandParameter userParam = new CommandParameter("message", "hello, i'm a message");
            myCommand.Parameters.Add(userParam);

            pipeline.Commands.Add(myCommand);
            Collection<PSObject> results = pipeline.Invoke();

            foreach (PSObject obj in results)
            {
                Console.Out.WriteLine(obj.ToString());
            }

            Console.ReadLine();
        }
    }
}
