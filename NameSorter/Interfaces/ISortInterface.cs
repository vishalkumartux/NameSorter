using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public interface ISortInterface<T>
    {
        /// <summary>
        /// Generic sort method for T type
        /// </summary>
        /// <param name="entityModels"></param>
        /// <returns> sorted list of type T</returns>
         List<T> Sort(List<T> entityModels);
       
    }
}
