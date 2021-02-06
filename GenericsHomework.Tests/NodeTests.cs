using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{

    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void EqualsOperator_GivenIntNode_EqualsIsTrue()
        {
            Node<int> node1 = new Node<int>(789);
            Node<int> node2 = node1;

            Assert.IsTrue(node1 == node2);
        }

        [TestMethod]
        public void NewInstance_GivenInt_NodeContainsInt()
        {
            Node<int> node1 = new Node<int>(789);

            Assert.AreEqual("789", node1.Data.ToString());
        }

        [TestMethod]
        public void ToString_GivenInt_EqualToString()
        {
            Node<int> node1 = new Node<int>(34);

            Assert.AreEqual("34", node1.ToString());

        }

        [TestMethod]
        public void Insert_Given2IntNodes_EqualToString()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);

            Assert.AreEqual("10 33 10", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4IntNodes_EqualToString()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);
            Node<int> node3 = node2.Insert(42);
            Node<int> node4 = node3.Insert(86);

            Assert.AreEqual("10 33 42 86 10", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()} {node1.Next.Next.Next.Next.ToString()}");
        }


        [TestMethod]
        public void NewInstance_GivenString_NodeContainsString()
        {
            Node<string> node1 = new Node<string>("Word");

            Assert.AreEqual("Word", node1.Data);

        }

        [TestMethod]
        public void ToString_GivenString_EqualToString()
        {
            Node<string> node1 = new Node<string>("Word");

            Assert.AreEqual("Word", node1.ToString());

        }

        [TestMethod]
        public void Insert_Given4StringNodes_EqualToString()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");

            Assert.AreEqual("First Second Third Fourth First", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()} {node1.Next.Next.Next.Next.ToString()}");

        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedOtherNodes()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual("Third", node3.Next.Next.Next.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference1()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            //Assert.AreEqual("Fourth",node1.Next.Next.Next.ToString());
            //Assert.AreEqual("Fourth",node1.Next.Next.ToString());
            Assert.AreEqual("Fourth", node1.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference2()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            //Assert.AreEqual("Fourth",node2.Next.Next.Next.Next.ToString());
            //Assert.AreEqual("Fourth",node2.Next.Next.ToString());
            Assert.AreEqual("Fourth", node2.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference3()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            //Assert.AreEqual("Fourth", node3.Next.Next.Next.Next.ToString());
            //Assert.AreEqual("Fourth", node3.Next.Next.ToString());
            Assert.AreEqual("First", node3.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference4()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            //Assert.AreEqual("Fourth", node4.Next.Next.Next.ToString());
            //Assert.AreEqual("Fourth", node4.Next.ToString());
            Assert.AreEqual("Fourth", node4.Next.ToString());
        }
    }
}
