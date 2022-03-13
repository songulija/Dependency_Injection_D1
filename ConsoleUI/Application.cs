using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// this class is basically start of our application
    /// </summary>
    public class Application : IApplication
    {
        IBusinessLogic _businessLogic;
        //for this class we pass IBusinessLogic
        //This is Constructor Injection. Basically in container i set things up
        //so whenever i ask for IBusinessLogic return new instance of BusinessLogin
        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        public void Run()
        {
            _businessLogic.ProcessData();
        }
    }
}
