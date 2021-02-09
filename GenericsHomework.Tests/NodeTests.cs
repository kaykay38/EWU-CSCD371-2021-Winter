using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework.Tests
{

    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void NewInstance_GivenInt_NodeContainsInt()
        {
            Node<int> node1 = new Node<int>(789);

            Assert.AreEqual("789", node1.Data.ToString());
        }

        [TestMethod]
        public void NewInstance_GivenString_NodeContainsString()
        {
            Node<string> node1 = new Node<string>("Word");

            Assert.AreEqual("Word", node1.Data);
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
            Assert.AreEqual("First", node1.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference2()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual("Second", node2.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference3()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual("Third", node3.Next.ToString());
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodesNextReference4()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual("Fourth", node4.Next.ToString());
        }

        [TestMethod]
        public void Contains_Given4IntValues_True()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.IsTrue(list.Contains(4));
        }

        [TestMethod]
        public void Contains_Given4IntValues_ContainsFirstIndex_True()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod]
        public void Contains_Given4IntArray_NodesListCreatedFromSingleInstance_True()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> list = CreateIntArray4NodeList(intArr1, intArr2, intArr3, intArr4);

            Assert.IsTrue(list.Contains(intArr2));
        }

        [TestMethod]
        public void CopyTo_GivenInt4ValuesCopyToIndex0_HasCopiedEqualToString()
        {
            int[] copiedArr = new int[4];
            int[] expectedArr = {1, 2, 3, 4};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 0); 
            Assert.AreEqual(expectedArr.ToString(), copiedArr.ToString());
        }

        [TestMethod]
        public void CopyTo_GivenInt4ValuesCopyToIndex2_HasCopiedEqualToString()
        {
            int[] copiedArr = new int[8];
            int[] expectedArr = {0, 0, 0, 1, 2, 3, 4, 0};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 2); 
            Assert.AreEqual(expectedArr.ToString(), copiedArr.ToString());
        }

        [TestMethod]
        public void EqualsOperator_GivenIntNode_EqualsIsTrue()
        {
            Node<int> node1 = new Node<int>(789);
            Node<int> node2 = node1;

            Assert.IsTrue(node1 == node2);
        }

        [TestMethod]
        public void GetEnumerator_ForeachAddToArrayList_Given4StringValues_EqualToString()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth");

            ArrayList arrayList = new();
            foreach (string item in list)
            {
                arrayList.Add(item);
            }
            Assert.AreEqual("{First, Second, Third, Fourth}", ToString(arrayList));
        }

        [TestMethod]
        public void Insert_Insert4IntNodesFromSingleInstance_InstantiatedContainsNums()
        {
            Node<int> list = new Node<int>(1);
            list = list.Insert(2);
            list = list.Insert(3);
            list = list.Insert(4);

            Assert.AreEqual("1 2 3 4", $"{list.Next.ToString()} {list.Next.Next.ToString()} {list.Next.Next.Next.ToString()} {list.Next.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4StringNodes_EqualToExpectedString()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");

            Assert.AreEqual("First Second Third Fourth First", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()} {node1.Next.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4IntNodes_EqualToExpectedString()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);
            Node<int> node3 = node2.Insert(42);
            Node<int> node4 = node3.Insert(86);

            Assert.AreEqual("10 33 42 86", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4IntArrayNodes_EqualToExpectedString()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> node1 = new Node<int[]>(intArr1);
            Node<int[]> node2 = node1.Insert(intArr2);
            Node<int[]> node3 = node2.Insert(intArr3);
            Node<int[]> node4 = node3.Insert(intArr4);
            Assert.IsTrue(node1.Contains(intArr2));
        }

        [TestMethod]
        public void Remove_Given4StringNodes_TrueRemoved()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth");
            Assert.IsTrue(list.Remove("Second"));
            Assert.AreEqual("First Third Fourth",$"{list.ToString()} {list.Next.ToString()} {list.Next.Next.ToString()}"); 
        }

        [TestMethod]
        public void ToString_GivenInt_EqualToString()
        {
            Node<int> node1 = new Node<int>(34);

            Assert.AreEqual("34", node1.ToString());
        }

        [TestMethod]
        public void ToString_GivenString_EqualToString()
        {
            Node<string> node1 = new Node<string>("Word");

            Assert.AreEqual("Word", node1.ToString());
        }

        public Node<int> CreateInt4NodeList(int num1, int num2, int num3, int num4)
        {
            Node<int> node1 = new Node<int>(num1);
            Node<int> node2 = node1.Insert(num2);
            Node<int> node3 = node2.Insert(num3);
            Node<int> node4 = node3.Insert(num4);
            return node1;
        }

        public Node<string> CreateString4NodeList(string string1, string string2, string string3, string string4)
        {
            Node<string> node1 = new Node<string>(string1);
            Node<string> node2 = node1.Insert(string2);
            Node<string> node3 = node2.Insert(string3);
            Node<string> node4 = node3.Insert(string4);
            return node1;
        }

        public Node<int[]> CreateIntArray4NodeList(int[] intArr1, int[] intArr2, int[] intArr3, int[] intArr4)
        {
            Node<int[]> node1 = new Node<int[]>(intArr1);
            Node<int[]> node2 = node1.Insert(intArr2);
            Node<int[]> node3 = node2.Insert(intArr3);
            Node<int[]> node4 = node3.Insert(intArr4);
            return node1;
        }

        public string ToString(ArrayList list) => "{" + string.Join(", ", list.ToArray()) + "}";
        public string ToString<T>(List<T> list) => "{" + string.Join(", ", list.ToArray()) + "}";
    }
}
