using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterNewInstance_GivenNullValue_ThrowArgumentNullException()
        {
            // Arrange
            // Act
            Jester jester = new Jester(null!, null!);
            // Assert
        }

        [TestMethod]
        public void Jester_ImplementIJokeServiceAndJokePrinter_WorkingJokeServiceAndJokePrinter()
        {
            // Arrange
            IJokeService iJokeService = new JokeService();
            IJokePrinter iJokePrinter = new JokePrinter();

            // Act
            Jester jester = new Jester(iJokeService, iJokePrinter);

            // Assert
            Assert.AreEqual(iJokeService, jester.jokeService);
            Assert.AreEqual(iJokePrinter, jester.jokePrinter);
        }

        [TestMethod]
        public void TellJoke_ValidJoke_ExcecutesWithoutException()
        {
            //Arrange
            string joke="Some bad dad joke that makes you roll your eyes.";
            Mock<IJokeService> mockJokeService = new Mock<IJokeService>();
            mockJokeService.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns(joke);

            Mock<IJokePrinter> mockJokePrinter = new Mock<IJokePrinter>();
            mockJokePrinter.SetupSequence(JokePrinter => JokePrinter.PrintJoke(joke));
            Jester jester = new Jester(mockJokeService.Object, mockJokePrinter.Object);

            // Act
            jester.TellJoke();

            // Assert
            mockJokePrinter.VerifyAll();
        }

        [TestMethod]
        public void TellJoke_GivenChuckNorris_CycleThroughLoop()
        {
            // Arrange
            Mock<IJokeService> mockJokeService = new ();
            mockJokeService.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Since 1940, the year Chuck Norris was born, roundhouse kick related deaths have increased 13,000 percent.")
                .Returns("Chuck Norris never retreats; He just attacks in the opposite direction.")
                .Returns("What did the full glass say to the empty glass?\nYou look drunk.")
                .Returns("Chuck Norris once won a game of Connect Four in three moves.")
                .Returns("Why couldn’t the toilet paper cross the road?\nBecause it got stuck in a crack.");
            
            Jester jester = new Jester(mockJokeService.Object, new JokePrinter());

            // Act
            jester.TellJoke();

            // Assert
            mockJokeService.Verify(jokeService => jokeService.GetJoke(), Times.Exactly(3));
        }
    }
}
