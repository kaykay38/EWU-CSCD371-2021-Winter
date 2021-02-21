using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Tests
{

    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void CsvRows_ForEachTwice_IteratesThroughDataTwice()
        {
            var sampleData = new SampleData();
            int result = 0;
            foreach(string item in sampleData.CsvRows)
            {
                result++;
            }

            Assert.AreEqual<int>(50, result);
            
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUnique()
        {
            var sampleData = new SampleData();
            bool result = true;

            int count = 0;       
            int otherItemIndex = 0;            
            foreach(string item in sampleData.GetUniqueSortedListOfStatesGivenCsvRows()) 
            {
                count = 0;
                foreach(string otherItem in sampleData.GetUniqueSortedListOfStatesGivenCsvRows())
                {
                    otherItemIndex = 0;
                    if(item.Equals(otherItem) && otherItemIndex > count){ // use count and otherItemIndex to compare each element with all other elements
                        result = false;                                     // without these the elements get compared to each other and that results in false positives
                    }
                    otherItemIndex++;
                }
                otherItemIndex = 0;
                count ++;
            }

            Assert.IsTrue(result); 
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_MatchsJoinGetUniqueSortedListOfStatesGivenCsvRows()
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
        public void GetAggregateSortedListOfStatesUsingCsvRows_AreAlphabetical()
        {
            var sampleData = new SampleData();
            bool result = true;

            int count = 0;
            int otherItemIndex = 0;            
            foreach(string item in sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(","))
            {
                count = 0;
                foreach(string otherItem in sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(","))
                {
                    otherItemIndex = 0;
                    if(string.Compare(item, otherItem) > 0 && otherItemIndex > count){
                        result = false;
                    }
                    otherItemIndex++;
                }
                otherItemIndex = 0;
                count ++;
            }
            Assert.IsTrue(result);
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