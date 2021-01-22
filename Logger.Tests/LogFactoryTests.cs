using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_NotConfiguredFileLogger_ReturnNull()
        {
            // Arrange
            LogFactory? logFactory = new LogFactory();
            // Act
            BaseLogger? baseLogger = logFactory.CreateLogger(nameof(LogFactoryTests));
            // Assert
            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void ConfigureFileLogger_FilePath_StoresFilePathInFileLogger()
        {
            // Arrange
            string actualResult = "", filePath = "testFile.txt";
            FileStream testFile = File.Create(filePath);
            testFile.Close();
            try
            {
                LogFactory? logFactory = new LogFactory();
                // Act
                logFactory.ConfigureFileLogger(filePath);
                FileLogger? fileLogger = (FileLogger?)logFactory.CreateLogger(nameof(LogFactoryTests));
         
                if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.FilePath))
                {
                    actualResult = fileLogger.FilePath;
                }
                // Assert
                Assert.AreEqual(filePath,actualResult);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void CreateLogger_ClassName_StoresClassNameInBaseLogger()
        {
            // Arrange
            string actualResult = "", filePath = "testPath.txt";
            FileStream testFile = File.Create(filePath);
            testFile.Close();
            try
            {
                LogFactory? logFactory = new LogFactory();
                logFactory.ConfigureFileLogger(filePath);
                FileLogger? fileLogger = (FileLogger?)logFactory.CreateLogger(nameof(LogFactoryTests));
            
                if(fileLogger != null && !string.IsNullOrEmpty(fileLogger.ClassName))
                {
                    actualResult = fileLogger.ClassName;
                }
                // Assert
                Assert.AreEqual(nameof(LogFactoryTests), actualResult);
            }
            finally
            {
                File.Delete(filePath);
            }
        }





    }
}
