using NUnit.Framework;
using System.IO;
using System.Text;

namespace Booster.CodingTest.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        /// <summary>
        /// Tests for <see cref="Program" />.
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
            Program.ProcessText(stream);

            //Assert
            Assert.AreEqual(stream.Length, Program.countChar);
        }

        [Test]
        public void ProcessText_4WordsText_4WordsDetected()
        {
            //Arrange
            string text = "This is a test!";
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new(byteArray);

            //Act
            Program.ProcessText(stream);

            //Assert
            Assert.AreEqual(text.Split().Length, Program.countWord);
        }
    }
}