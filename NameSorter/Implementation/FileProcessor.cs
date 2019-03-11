using Microsoft.Extensions.Logging;
using NameSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Implementation
{
    public class FileProcessor : IFileProcessorInterface
    {
        private readonly ILogger<FileProcessor> _logger;
        public FileProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FileProcessor>();
        }
        public List<string> ReadFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    return File.ReadAllLines(filePath).ToList();
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool WriteFile(List<string> listOfString, string outputFilePath)
        {
            var result = false;
            try
            {
                File.WriteAllLines(outputFilePath, listOfString);
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result = false;
            }
            return result;
            

        }
    }
}
