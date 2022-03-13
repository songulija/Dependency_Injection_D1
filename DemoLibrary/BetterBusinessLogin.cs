using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BetterBusinessLogin : IBusinessLogic
    {
        ILogger _logger;
        IDataAccess _dataAccess;
        //ILogger and IDataAccess have to be passed to constructor
        //This is Constructor Injection. Basically in container i set things up
        //so whenever i ask for ILogger,IDataAccess return new instance of Logger and DataAccess
        public BetterBusinessLogin(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
            _logger.Log("Starting the processing of data.");
            Console.WriteLine();
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            Console.WriteLine();
            _logger.Log("Finished processing of the data.");
            Console.WriteLine();
        }
    }
}
