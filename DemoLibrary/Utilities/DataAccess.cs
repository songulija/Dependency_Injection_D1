using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;
        //This is Constructor Injection. In ContainerConfig using Dependency Inj.
        //i set when asking for ILogger return new instance of Logger
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }
        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            //can just call Logger method, dont need to instantiate becouse of Dependency Injection
            _logger.Log("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            _logger.Log("Saving data");
        }
    }
}
