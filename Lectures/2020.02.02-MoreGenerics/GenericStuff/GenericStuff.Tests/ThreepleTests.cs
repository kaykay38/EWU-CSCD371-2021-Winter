using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericStuff.Tests
{
    [TestClass]
    public class ThreepleTests
    {
        [TestMethod]
        public void CreateThreeple()
        {
            _ = new Threeple<int,string,Guid>(42, "Inigo", Guid.NewGuid());
            _ = new Threeple<string, Guid, int>("Inigo", Guid.NewGuid(), 42);
        }

        [TestMethod]
        public void VerifyProperties()
        {
            Threeple<int, string, Guid> threeple = new (42, "Inigo", Guid.NewGuid());
            Assert.AreEqual<int>(42, threeple.First);
        }

        [TestMethod]
        public void GivenThreeple_ItemsAreInOrder()
        {
            ThreepleDescription<SampleCanDoDescription, string, Guid> threeple =
                new (new SampleCanDoDescription(), "Inigo", Guid.NewGuid());
            Assert.IsTrue(threeple.Description.Length > 0);
            Assert.AreEqual<string>("First: 42; Second: Inigo; Third: ;", threeple.Description);
        }

        public static (int, string, Guid) Deconstruct<T1, T2, T3>(Threeple<T1, T2, T3> threeple)
        {
            return (threeple.First, threeple.Second, threeple.Third);
        }

        [TestMethod]
        public void Serialization()
        {
            string output = Serializer.Deserialize<string>(42);
        }

        [TestMethod]
        public void Variance()
        {
            Threeple<int, int, int> threepleOne = new (42, 43, 44);
            Threeple<object, object, object> threepleTwo;
            //threepleOne = threepleTwo; // this cannot always work // casting issues
        }

        [TestMethod]
        public void Serializer()
        {
            //Serializer.Serialize<object>("");
            Serializer<object> serializer = default;
            serializer.Serialize(42);
            Serializer<int> serializerTwo = default;
            //serializerTwo.Serialize(new object()); // cannot convert object to int
            //object output = Serializer.Deserialize<string>(42);
        }
    }
}
