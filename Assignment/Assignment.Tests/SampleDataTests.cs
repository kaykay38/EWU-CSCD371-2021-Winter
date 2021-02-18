using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Tests
{

    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void CsvRows_foreachWorks()
        {
            var sampleData = new SampleData();
            int result = 0;
            foreach(string item in sampleData.CsvRows)
            {
                result++;
            }

            foreach(string item in sampleData.CsvRows)
            {
                result++;
            }

            Assert.AreEqual<int>(100, result);
            
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_Match()
        {
            var sampleData = new SampleData();
            string? result = null;
            foreach(string item in sampleData.GetUniqueSortedListOfStatesGivenCsvRows())
            {
                if(result == null)
                {
                    result = item;
                }
                else
                {
                    result = string.Join(",", result, item);
                }
                
            }

            Assert.AreEqual<string>(result!, sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
            
        }

        [TestMethod]
        public void People_Test()
        {
            var sampleData = new SampleData();
            string result = "\n";
            foreach(Person item in sampleData.People)
            {
                    result += PersonToString(item) + "\n";
            }

            Assert.AreEqual<string>("", result); // bad test - used this to see the output
        }

         [TestMethod]
        public void FilterByEmailAddress_Test()
        {
            var sampleData = new SampleData();
            string result = "";
            Predicate<string> filter = (string str) => { return str == "atoall@fema.gov"; };

            foreach((string FirstName, string LastName) item in sampleData.FilterByEmailAddress(filter))
            {
                   result += item.FirstName + " " + item.LastName;
            }

            Assert.AreEqual<string>("", result); // bad test - used this to see the output
        }

        private string PersonToString(Person person)
        {
            return $"{person.Address.State}, {person.Address.City}, {person.Address.Zip}, {person.FirstName} {person.LastName}, {person.EmailAddress}";
        }

    }
}