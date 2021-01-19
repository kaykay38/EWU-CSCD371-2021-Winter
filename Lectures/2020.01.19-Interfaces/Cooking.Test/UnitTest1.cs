using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cooking.Test
{
    
    public record Waffle;
    public   
    public class WaffleCook
    {
        private ICookingService Service { get; } 
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [TestClass]
    public class WaffleCookTests
    {
        [TestMethod]
        public void TestingCookingService() : ICookingService
        {
            public string Create() => "Tuna Fish";
        }
    }
}
