using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        
        [TestInitialize]
        public void setup()
        {
            // Arrange
            // Act
            // Assert
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            try
            {
                // Act
                FileLogger fileLogger = new FileLogger(null);
                fileLogger.Log();
            }
            catch (FileNotFoundException exception)
            {
                // Assert
                Assert.AreEqual(, exception);
                throw;
            }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            // Act
            // Assert
        }

    }
}
