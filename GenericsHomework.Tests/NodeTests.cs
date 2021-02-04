using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsHomework;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void createLL()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);

            Assert.AreEqual("10 33 10", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()}");
      
        }
    }
}
