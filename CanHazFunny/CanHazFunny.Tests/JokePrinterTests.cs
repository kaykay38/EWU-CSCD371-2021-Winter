using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokePrinterTests
    {

        [TestMethod]
        public void PrintJoke_ValidJoke_PrintsCorrectJoke()
        {
            // Arrange
            string joke="Some bad dad joke that makes you roll your eyes.";
            JokePrinter jokePrinter = new JokePrinter();

            // Act
            // Pipes Console.WriteLine to a file to test if the 
            // JokePrinter.PrintJoke method prints the correct output to console.
            using ( StreamWriter streamWriter= new StreamWriter("out.txt"))
            {
                Console.SetOut(streamWriter);
                jokePrinter.PrintJoke(joke);
            }

            // Assert
            string[] printerConsoleOutputArray = File.ReadAllLines("out.txt");
            // This ensures that if the joke contains multiple lines
            // that it will be correctly tested.
            string printerConsoleOutputString = string.Join("\n",printerConsoleOutputArray);
            Assert.AreEqual(joke, printerConsoleOutputString);
       }
    }

}
