using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NumSet.Writer;
using System.IO;
using System.Linq;

namespace NumSet.Tests
{
    [TestClass]
    public class SetWriterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewInstance_GivenNullFilePath_ThrowArgumentNullException()
        {
            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);

            using (SetWriter writer = new SetWriter(null!))
            writer.WriteSet(numSet1);
        }

        [TestMethod]
        public void NewInstance_ValidFilePath_InstantiatesSetWriterAsTypeStreamWriter()
        {
            string filePath = Path.GetTempFileName();

            using(SetWriter setWriter = new SetWriter(filePath))
            using(StreamWriter streamWriter = new StreamWriter(filePath))

            Assert.AreEqual(setWriter.Writer.GetType(), streamWriter.GetType());
        }

        [TestMethod]
        public void WriteSet_GivenValidSet_EqualStrings()
        {
            string filePath = Path.GetTempFileName();

            NumSet numSet1 = new NumSet(12, 7, 934, 43, 0, 56);

            using (SetWriter writer = new SetWriter(filePath))
            writer.WriteSet(numSet1);

            string expectedFirstLine = File.ReadLines(filePath).First();

            Assert.AreEqual(expectedFirstLine, "{12, 7, 934, 43, 0, 56}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteSet_GivenNullNumSet_ThrowsArgumenetNullException()
        {
            string path = Path.GetTempFileName();

            NumSet numSet1 = new NumSet(null!);

            using (SetWriter writer = new SetWriter(path))
            writer.WriteSet(numSet1);

        }

    }
}
