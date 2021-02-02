using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generics.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateThreeple()
        {
            _ = new Threeple<int,string,Guid>(42, "Inigo", Guid.NewGuid());
            _ = new Threeple<string,Guid,int>("Inigo", Guid.NewGuid(), 42);
        }

        [TestMethod]
        public void VerifyProperties()
        {
            Threeple<int,string,Guid> threeple = new (42, "Inigo", Guid.NewGuid());
            Assert.AreEqual<int>(42, threeple.First); //Use generic version
        }

        [TestMethod]
        public void GivenThree_ItemsAreInOrder()
        {
            Threeple<SampleCanDoDescription,string,Guid> threeple = new ( new SampleCanDoDescription(42, "Inigo", Guid.NewGuid())); 
            Assert.IsTrue(threeple.Description.Length > 0);
            ThreepleDescrition<int,string,Guid> threepleDescrition = new (42, "Inigo", Guid.NewGuid());
            Assert.IsTrue(threeple.Description.Length > 0);
            Assert.AreEqual<string>("First: 42; Second: Inigo; Third: ;", threeple.Description);
        }
    }
}
