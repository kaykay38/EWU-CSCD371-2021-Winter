using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        // ADDED this test
        [TestMethod]
        public void LoadQuestions_NotNull()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                for (int i = 0; i < questions.Length; i++)
                {
                    Assert.IsNotNull(questions[i]);
                }
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        // ADDED this test
        [TestMethod]
        public void RandomQuestions_NotSameOrder()
        {

            // Arrange
            bool[] used = new bool[5];
            int randomNumber;
            bool notFirstIndex = false;
            // Act
            for (int i = 0; i < 5; i++)
            {
                randomNumber = Program.GetRandomNumber(used);
                if (randomNumber != 0)
                {
                    notFirstIndex = true;
                }
            }
            // Assert
            Assert.IsTrue(notFirstIndex);
        }

        //ADDED this -Kiana
        [DataTestMethod]
        [DataRow(new bool[] { false, false, false })]
        [DataRow(new bool[] { true, false, false })]
        [DataRow(new bool[] { false, true, false, true })]
        public void RandomQuestions_NumberInBoundsOfArray(bool[] used)
        {
            // Arrange

            // Act
            int randomNumber = Program.GetRandomNumber(used);

            // Assert
            Assert.IsTrue(randomNumber >= 0);
            Assert.IsTrue(randomNumber < used.Length);
        }

        //ADDED this -Kiana
        [DataTestMethod]
        [DataRow(new bool[] { false, false, false })]
        [DataRow(new bool[] { true, false, false })]
        [DataRow(new bool[] { false, true, false, true })]
        public void RandomQuestions_NoRepeat(bool[] used)
        {
            // Arrange

            // Act
            int randomNumber = Program.GetRandomNumber(used);

            // Assert
            Assert.AreEqual(used[randomNumber], false);
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));

        }

        [DataTestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses,
                int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }


        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }
    }
}