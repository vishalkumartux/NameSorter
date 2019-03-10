using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Interfaces
{
    public interface IApplication
    {
        /// <summary>
        /// perform sorting of names from input file and generate output file
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <returns></returns>
        bool performSorting(string inputFilePath,string outputFilePath);
    }
}
