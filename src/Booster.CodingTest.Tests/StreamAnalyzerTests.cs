using NUnit.Framework;
using System.IO;
using System.Text;

namespace Booster.CodingTest.Tests
{
    [TestFixture]
    public class StreamAnalyzerTests
    {
        /// <summary>
        /// Tests for <see cref="StreamAnalyzer" />.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProcessText_13CharactersText_13CharactersDetected()
        {
            //Arrange
            string text = "Testing 1-2-3";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            Assert.AreEqual(stream.Length, StreamAnalyzer.CountChar);
        }

        [Test]
        public void ProcessText_4WordsText_4WordsDetected()
        {
            //Arrange
            string text = "This is a test!";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            Assert.AreEqual(text.Split().Length, StreamAnalyzer.CountWord);
        }

        [Test]
        public void ProcessText_WordsText_5SmallestWords()
        {
            //Arrange
            string[] smallestWords = { "a", "i", "e", "is", "to" };
            string text = "This test is intended to allow a potential candidate to demonstrate their technical " +
                "proficiency and approach to software development, while solving a relatively trival problem.# " +
                "The challenge:Write an application(console, web, forms or other.NET application type of your " +
                "choosing) which will continually read and process text from a provided stream.Your application" +
                " should process and output in real time(i.e. as you read it from the stream) the following " +
                "information about the stream:";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            CollectionAssert.AreEquivalent(smallestWords, StreamAnalyzer.SmallestWords);
        }

        [Test]
        public void ProcessText_WordsText_5LargestWords()
        {
            //Arrange
            string[] largestWords = { "demonstrate", "proficiency", "development", "application", "continually" };
            string text = "This test is intended to allow a potential candidate to demonstrate their technical " +
                "proficiency and approach to software development, while solving a relatively trival problem.# " +
                "The challenge:Write an application(console, web, forms or other.NET application type of your " +
                "choosing) which will continually read and process text from a provided stream.Your application" +
                " should process and output in real time(i.e. as you read it from the stream) the following " +
                "information about the stream:";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            CollectionAssert.AreEquivalent(largestWords, StreamAnalyzer.LargestWords);
        }

        [Test]
        public void ProcessText_WordsText_10MostFrequentlyAppearingWords()
        {
            //Arrange
            string[] frequentWords = { "the", "to", "stream", "application", "and", "a", "your", "read", "process", "from" };
            string text = "This test is intended to allow a potential candidate to demonstrate their technical " +
                "proficiency and approach to software development, while solving a relatively trival problem.# " +
                "The challenge:Write an application(console, web, forms or other.NET application type of your " +
                "choosing) which will continually read and process text from a provided stream.Your application" +
                " should process and output in real time(i.e. as you read it from the stream) the following " +
                "information about the stream:";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            CollectionAssert.AreEquivalent(frequentWords, StreamAnalyzer.FrequentWords);
        }

        [Test]
        public void ProcessText_WordsText_MostFrequentlyAppearingCharacters()
        {
            //Arrange
            char[] frequentCharacters = { '&', 'e', 'f', ' ', 'g', '!', '@', 'a' };
            string text = "a eeeeeeeee ffffff gggg @@ &&&&&&&&&&&&&&&&&&&&&&&&& !!!";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            StreamAnalyzer.ProcessText(stream);

            //Assert
            CollectionAssert.AreEqual(frequentCharacters, StreamAnalyzer.FrequentChars);
        }
    }
}