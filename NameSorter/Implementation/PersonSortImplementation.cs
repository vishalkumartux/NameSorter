using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Implementation
{
    public class PersonSortImplementation : ISortInterface<PersonModel>
    {
        public List<PersonModel> Sort(List<PersonModel> entityModels)
        {

            for (int i = 0; i < entityModels.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (entityModels[j - 1].CompareTo(entityModels[j])>0)
                    {
                        var temp = entityModels[j - 1];
                        entityModels[j - 1] = entityModels[j];
                        entityModels[j] = temp;
                    }
                }
            }

            return entityModels;

        }
    }
}
