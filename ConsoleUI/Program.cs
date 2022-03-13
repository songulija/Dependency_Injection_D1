using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContainerConfig.Configure configures the container. that container holds
            //all instantiations setup. our design how to instantiate something.
            var container = ContainerConfig.Configure();
            //in using  container.BeginLifetimeScope. It set NEW scope for instances beeing passed out
            using (var scope = container.BeginLifetimeScope())
            {
                //this saying that i need i IApplication object. give me IApplication manually
                //this all is to get IApplication(which will return instance of Application) and call its
                //method Run
                var app = scope.Resolve<IApplication>();
                //returns Application instance and i can call Run method
                app.Run();
            }
            Console.ReadLine();
        }
    }
}
