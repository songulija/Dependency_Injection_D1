using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Top level object, the very start of program.cs will control all our dependencies
    /// registering dependencies in the top(start)
    /// This ContainerConfig handles a lot of behind scenes, how to instantiate and rest.
    /// It's just passing those new Intances in when we are asking them in constructor. like in BusinessLogin,Application
    /// </summary>
    public static class ContainerConfig
    {
        //this method job is to configure the container
        public static IContainer Configure()
        {
            //creating container builder. ContainerBuilder is place to store definitions
            //of all diferrent classes i want to instantiate
            var builder = new ContainerBuilder();
            //this means whenerver you ASK for IApplication it will return 
            //instance of Application. whenever i ask for IApplication it CREATES new instance of it 
            builder.RegisterType<Application>().As<IApplication>();
            
            //registering BusinessLogin class. whenever i look for IBusinessLogic interface
            //it will return instance of BusinessLogin 
            builder.RegisterType<BetterBusinessLogin>().As<IBusinessLogic>();
            
            //register all types in assembly. Load assembly, name of whole DemoLibrary.
            //then find in DemoLibrary where Namespace(whatever obj you find) contains for Utilities
            //basically checking all obj Like DataAccess,Logger and checking their namespace DemoLibrary.Utilities
            //then getting interface of that found class where interface name "i.Name" is equal to "I" plus class name
            //like DataAccess and IDataAccess. doing it for every class in Utilities folder
            //so this will map Interfaces to their implementations(classes)
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            //basically what i'm trying to do is in Utitlities folder, give me all classes and register them
            //then link them up to matching interface
            
            
            //and actually building it
            return builder.Build();
        }
    }
}
