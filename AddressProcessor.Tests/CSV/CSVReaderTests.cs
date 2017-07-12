using AddressProcessing.CSV;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class CSVReaderTests
    {
        private CSVReader _reader;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _reader = new CSVReader();
        }

        [Test]
        [ExpectedException("System.IO.FileNotFoundException")]
        public void OpenFile_ThrowsException_IfFileDoesnotExists()
        {
            //Arrange
            var dir = Environment.CurrentDirectory + "\\test_data\\test.csv";
            //Act
            _reader.OpenFile(dir);
        }

        [Test]
        public void Read_ReturnsTrue_WhenFileHasValidData()
        {
            //Arrange
            var dir = Environment.CurrentDirectory + "\\test_data\\contacts.csv";
            //Act
            _reader.OpenFile(dir);
            //Assert
            Assert.IsTrue(_reader.Read());
        }

        [Test]
        public void Read_ReturnsFalse_WhenFileHasNoData()
        {
            //Arrange
            var dir = Environment.CurrentDirectory + "\\test_data\\empty.csv";
            //Act
            _reader.OpenFile(dir);
            //Assert
            Assert.IsFalse(_reader.Read());
        }

        [Test]
        public void Read_ReturnsTrueWithOutArgs_WhenFileHasValidData()
        {
            //Arrange
            var dir = Environment.CurrentDirectory + "\\test_data\\contacts.csv";
            _reader.OpenFile(dir);
            string col1 = string.Empty, col2 = string.Empty;
            //Act
            Assert.IsTrue(_reader.Read(out col1, out col2));
            //Assert
            Assert.AreEqual("Shelby Macias", col1);
            Assert.AreEqual("3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|England", col2);
            
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            _reader.Dispose();
        }
    }
}
