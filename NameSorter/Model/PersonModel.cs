using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSorter.Model
{
    public class PersonModel:IComparable<PersonModel>
    {
        private string lastName;
        private List<string> givenName;
        private string separator;

        public string LastName { get => lastName; set => lastName = value; }
        public List<string> GivenName { get => givenName; set => givenName = value; }
        public string Separator { get => separator; set => separator = value; }

        /// <summary>
        /// PersonModel constructor
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="sep"></param>
        public PersonModel(string fullName,string sep)
        {
            Separator = sep;
            GivenName = this.GetGivenName(fullName);
            LastName = this.GetLastName(fullName);
            
        }
        /// <summary>
        /// get last name of the given full name
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private string GetLastName(string fullName)
        {
            var splitedNames = this.splitFullName(fullName);
            return splitedNames.Last();
        }

        /// <summary>
        /// get given name from a full name of the person
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private List<string> GetGivenName(string  fullName)
        {
            var splitedNames = this.splitFullName(fullName);
            splitedNames.RemoveAt(splitedNames.Count - 1);
            return splitedNames;
        }

        /// <summary>
        /// split given full name with separator
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private List<string> splitFullName(string fullName)
        {
            return fullName.Split(Separator).ToList();
        }

        /// <summary>
        /// compareTo imepelmentation
        /// </summary>
        /// <param name="other"></param>
        /// <returns> return 0 if equal , 1 if this person is greater than other,-1 otherwise</returns>
        public int CompareTo(PersonModel other)
        {
            int result = 0;
            if (string.Compare(this.LastName, other.LastName, true) == 0)
            {
                int i = 1;
                while (i <= this.GivenName.Count || i <= other.GivenName.Count)
                {
                    if (this.GivenName.Count < i || other.GivenName.Count < i)
                    {
                        result = this.GivenName.Count > i ? 1 : -1;
                        break;
                    }

                    if (string.Compare(this.GivenName[i - 1], other.GivenName[i - 1], true) != 0)
                    {
                        result = string.Compare(this.GivenName[i - 1], other.GivenName[i - 1], true);
                        break;
                    }
                    i++;
                }

            }
            else
                result = string.Compare(this.LastName, other.LastName, true);
            return result;
        }
    }
}
