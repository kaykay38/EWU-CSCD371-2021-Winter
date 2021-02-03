using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NumSet.Tests
{
    [TestClass]
    public class NumSetTests
    {


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewInstance_GivenNullParams_ThrowArgumentNullException()
        {

            NumSet numSet = new NumSet(null!);
        }

        [TestMethod]
        public void NewInstance_GiveNoParams_IsInstantiatedAsEmptyHashSet()
        {
            NumSet numSet = new NumSet();

            bool isEmptyHashSet = numSet.Set.SetEquals(new HashSet<int>());
            Assert.IsTrue(isEmptyHashSet);
        }

        [TestMethod]
        public void NewInstance_GivenValidSet_IsInstantiatedAndValuesStored()
        {
            // Arrange
            NumSet numSet = new NumSet(12, 7, 934, 43, 0, 56);

            var numSetArray = new int[] {12, 7, 934, 43, 0, 56};
            var expected = new HashSet<int>(numSetArray);

            bool isEqualToHashSet = numSet.Set.SetEquals(expected);
            Assert.IsTrue(isEqualToHashSet);
        }

        [TestMethod]
        public void ToString_GivenValidSet_EqualToString()
        {
            var numSetArray = new int[] { 12, 7, 934, 43, 0, 56 };
            NumSet numSet = new NumSet(numSetArray);

            Assert.AreEqual("{12, 7, 934, 43, 0, 56}", numSet.ToString());
        }

        [TestMethod]
        public void GetHashCode_GivenEqualNumSet_EqualHashCode()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet numSet2 = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.AreEqual(numSet1.GetHashCode(), numSet2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_Value_EqualToSumOfArrayIndexItemsHashcodeTimes7()
        {
            var numSetArray = new int[] { 12, 7, 934, 43, 0, 56 };
            NumSet numSet = new NumSet(numSetArray);

            int expectedHashCode = 0;
            for (int i = 0; i < numSetArray.Length; i++)
            {
                expectedHashCode += numSetArray[i].GetHashCode();
            }
            expectedHashCode *= 7;

            Assert.AreEqual(expectedHashCode, numSet.GetHashCode());
        }

        [TestMethod]
        public void Equals_GivenEqualNumSet_True()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet numSet2 = new NumSet(12, 7, 934, 43, 0, 56);

            bool isEqual = numSet1.Equals(numSet2);
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void Equals_SelfReference_True()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.IsTrue(numSet1.Equals(numSet1));
        }

        [TestMethod]
        public void Equals_GivenObjectNotNumSet_False()
        {
            NumSet numSet = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.IsFalse(numSet.Equals("Hello World"));
        }

        [TestMethod]
        public void Equals_GivenSameSizeNotEqualNumSet_False()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet numSet2 = new NumSet(43, 10, 23, 0, 874, 2);

            bool isEqual = numSet1.Equals(numSet2);
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void Equals_GivenNotSameSizeNotEqualNumSet_False()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet numSet2 = new NumSet(23, 0, 874, 2);

            bool isEqual = numSet1.Equals(numSet2);
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void EqualEqualOperator_GivenBothNull_True()
        {
            NumSet? numSet1 = null;
            NumSet? numSet2 = null;

            Assert.IsTrue((numSet1!) == (numSet2!));
        }

        [TestMethod]
        public void EqualEqualOperator_GivenFirstNull_False()
        {
            NumSet? numSet1 = null;
            NumSet? numSet2 = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.IsFalse((numSet1!) == (numSet2!));
        }

        [TestMethod]
        public void EqualEqualOperator_GivenEqualNumSet_True()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.IsTrue(numSet1 == numSet2);
        }

        [TestMethod]
        public void EqualEqualOperator_GivenNotEqualNumSet_False()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(23, 30, 0, 5, 1743);

            Assert.IsFalse(numSet1 == numSet2);
        }

        [TestMethod]
        public void NotEqualOperator_GivenNotEqualNumSet_True()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(23, 30, 0, 5, 1743);

            Assert.IsTrue(numSet1 != numSet2);
        }

        [TestMethod]
        public void NotEqualOperator_GivenEqualNumSet_False()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(12, 7, 934, 43, 0, 56);

            Assert.IsFalse(numSet1 != numSet2);
        }

        [TestMethod]
        public void PlusOperator_GivenNotEqualNumSetWithSomeMatchingValues_ReturnsJoinedNumSet_True()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(23, 30, 0, 5, 1743);
            NumSet numSet3 = numSet1+numSet2;
            NumSet expectedNumSet = new NumSet(12, 7, 934, 43, 0, 56, 23, 30, 5, 1743);
            Assert.IsTrue(expectedNumSet == numSet3);
        }

        [TestMethod]
        public void PlusOperator_GivenEqualNumSet_ReturnsSameValuesNumSet_True()
        {
            NumSet? numSet1 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(12, 7, 934, 43, 0, 56);
            NumSet numSet3 = numSet1+numSet2;
            NumSet expectedNumSet = new NumSet(12, 7, 934, 43, 0, 56);
            Assert.IsTrue(expectedNumSet == numSet3);
        }

        [TestMethod]
        public void MinusOperator_GivenSmallerNumSetWithSomeMatchingValues_ReturnsSubstractedNumSet_True()
        {
            NumSet? numSet1 = new NumSet(12, 7, 87, 934, 43, 0, 56);
            NumSet? numSet2 = new NumSet(23, 30, 0, 43, 7);
            NumSet numSet3 = numSet1-numSet2;
            NumSet expectedNumSet = new NumSet(12, 87, 934, 56);
            Assert.IsTrue(expectedNumSet == numSet3);
        }

        [TestMethod]
        public void MinusOperator_GivenBiggerNumSetWithSomeMatchingValues_ReturnsSubstractedNumSet_True()
        {
            NumSet? numSet1 = new NumSet(23, 30, 0, 43, 7);
            NumSet? numSet2 = new NumSet(12, 7, 87, 934, 43, 0, 56);
            NumSet numSet3 = numSet1-numSet2;
            NumSet expectedNumSet = new NumSet(23, 30);
            Assert.IsTrue(expectedNumSet == numSet3);
        }

        [TestMethod]
        public void MinusOperator_GivenEqualNumSet_ReturnsEmptyNumSet_True()
        {
            NumSet? numSet1 = new NumSet(23, 30, 0, 43, 7);
            NumSet? numSet2 = new NumSet(23, 30, 0, 43, 7);
            NumSet numSet3 = numSet1-numSet2;
            NumSet expectedNumSet = new NumSet();
            Assert.IsTrue(expectedNumSet == numSet3);
        }

        [TestMethod]
        public void ImplicitCastToIntArray_GiveValidNumSet_IsEqualToIntArray()
        {
            NumSet? numSet1 = new NumSet(23, 30, 0, 43, 7);
            int[] numSetArray = numSet1;
            int[] expectedArray = new int[]{23, 30, 0, 43, 7};
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], numSetArray[i]);
            }
        }

    }
}
