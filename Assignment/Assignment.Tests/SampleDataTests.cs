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

            Assert.AreEqual<int>(50, result);
            
        }
    }
}