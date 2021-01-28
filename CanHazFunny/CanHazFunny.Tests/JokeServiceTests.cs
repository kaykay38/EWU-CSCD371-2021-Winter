using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void GetJoke_ReturnsAJoke_NotNull()
        {
            // Arrange
            JokeService jokeService = new JokeService();

            // Assert
            Assert.IsNotNull(jokeService.GetJoke());
        }
    }
}
