using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Interfaces
{
    public interface IFileProcessorInterface
    {
        /// <summary>
        /// Read file from given file path 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>lines in the file as list of strings</returns>
        List<String> ReadFile(string filePath);

        /// <summary>
        /// write files from given set of lines to the provided file path
        /// </summary>
        /// <param name="listOfString"></param>
        /// <param name="outputFilePath"></param>
        /// <returns>return true if successful else false</returns>
        Boolean WriteFile(List<String> listOfString, string outputFilePath);

    }
}
