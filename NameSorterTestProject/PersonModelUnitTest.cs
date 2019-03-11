using NameSorter.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTestProject
{
    public class PersonModelUnitTest
    {
        private PersonModel person = new PersonModel("Vishal Kumar", " ");

        [Theory]
        [InlineData("Vishal Kumar","kumar")]
        [InlineData("John clark sam","sam")]
        [InlineData("Ross Morgan","Morgan")]
        public void GetLastNameTest(string fullName,string lastName)
        {
            var person = new PersonModel(fullName," ");
            Assert.True(string.Compare(person.LastName,lastName,true)==0);
        }

        [Theory]
        [InlineData("Vishal Kumar", "Vishal" )]
        [InlineData("John clark sam", "John clark")]
        [InlineData("Ross Morgan", "Ross")]
        public void GetGivenNameTest(string fullName,string expectedGivenName)
        {
            var person = new PersonModel(fullName, " ");
            Assert.True(string.Compare(string.Join(" ",person.GivenName), expectedGivenName, true) == 0);
        }

        [Theory]
        [InlineData("john yorder",-1)]
        [InlineData("aboy borden", 1)]
        [InlineData("Vishal Kumar", 0)]
        public void CompareTest(string fullName, int expectedResult)
        {
            //Arrange
            var personToTest = new PersonModel(fullName, " ");

            //Act
            var compareResult = person.CompareTo(personToTest);

            //Assert
            Assert.True(compareResult==expectedResult);
        }
    }
}
