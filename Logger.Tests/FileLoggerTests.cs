using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_NullFile_ThrowsArgumentNullException()
        {
            // Act
            FileLogger? fileLogger = new FileLogger(null!);
        }

        [TestMethod]
        public void FileLogger_SetsFilePath()
        {
            // Arrange
            string actualResult = "", expectedResult = "test.txt";
            // Act
            FileLogger? fileLogger = new FileLogger(expectedResult);
            if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
            {
                actualResult = fileLogger.FilePath;
            }
            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Log_InvalidFile_ThrowsFileNotFoundException()
        {
            // Act
            FileLogger? fileLogger = new FileLogger("invalidFile.txt");
            fileLogger.Log(LogLevel.Error, "File not found");
        }

        [TestMethod]
        public void Log_ValidFile_AppendsToFile()
        {
            // Arrange
            string filePath = "testFile.txt"; 
            FileStream testFile = File.Create(filePath);
            testFile.Close();
            try
            {
                LogFactory? logFactory = new LogFactory();
                logFactory.ConfigureFileLogger(filePath);
                FileLogger? fileLogger = (FileLogger?)logFactory.CreateLogger(nameof(FileLoggerTests));
                if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
                {
                    // Act
                    fileLogger.Log(LogLevel.Error,  "Testing...");
                }
                string lastLine = File.ReadLines(filePath).Last();

                // Assert
                Assert.AreEqual($"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {nameof(FileLoggerTests)} {LogLevel.Error}: Testing...", lastLine);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
