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
        public List<string> ReadFile(string filePath)
        {
            if (File.Exists(filePath))
                return File.ReadAllLines(filePath).ToList();
            else
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
                result = false;
            }
            return result;
            

        }
    }
}
