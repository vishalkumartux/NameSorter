using Microsoft.Extensions.Logging;
using NameSorter.Interfaces;
using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Implementation
{
    public class Application : IApplication
    {
        private readonly IFileProcessorInterface _fileProcssor;
        private readonly ISortInterface<PersonModel> _sortInterface;
        private readonly ILogger<Application> _logger;
        public Application(ILoggerFactory loggerFactory, IFileProcessorInterface fileProcessor,ISortInterface<PersonModel> sortInterface)
        {
            _fileProcssor = fileProcessor;
            _sortInterface = sortInterface;
            _logger = loggerFactory.CreateLogger<Application>();

        }
        public bool performSorting(string inputFilePath,string outputFilePath)
        {
            var result = false;
            try
            {
                var sortedNameList = new List<string>();
                List<PersonModel> listOfPerson = new List<PersonModel>();

                var lines = _fileProcssor.ReadFile(inputFilePath.ToString());
                foreach (var line in lines)
                {
                    listOfPerson.Add(new PersonModel(line, " "));
                }
                if (listOfPerson.Count > 0)
                {

                    var sortedPerson = _sortInterface.Sort(listOfPerson);
                    
                    foreach (var record in sortedPerson)
                    {
                        var personFullName = string.Join(" ", record.GivenName) + " " + record.LastName;
                        Console.WriteLine(personFullName);
                        sortedNameList.Add(personFullName);
                    }
                    result = _fileProcssor.WriteFile(sortedNameList, outputFilePath);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;
        }
    }
}
