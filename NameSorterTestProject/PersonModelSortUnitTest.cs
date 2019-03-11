using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.Implementation;
using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NameSorterTestProject
{
    public class PersonModelSortUnitTest
    {
        [Fact]
        public void SortTest()
        {
            ///Arrange
            var personListInput = new List<PersonModel>(new[]{new PersonModel("Vishal Kumar"," "),
                new PersonModel("Tint Thomas"," "),
                new PersonModel("abay border"," ") }
            );

            var expectedResultList= new List<PersonModel>(new[]{new PersonModel("abay border"," "),
                new PersonModel("Vishal Kumar"," "),
                new PersonModel("Tint Thomas"," ") }
            );

            //ACT
            var mock = new Mock<ILoggerFactory>();
            ILoggerFactory logger = mock.Object;

            
            var personSort = new PersonSortImplementation(logger);
            var result=personSort.Sort(personListInput);
            Assert.True(string.Compare(result[0].LastName, "border", true) == 0);
                Assert.True(string.Compare(result[1].LastName, "Kumar", true) == 0);
        }
    }
}
