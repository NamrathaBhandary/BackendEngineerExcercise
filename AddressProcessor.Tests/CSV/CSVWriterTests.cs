using AddressProcessing.CSV;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class CSVWriterTests
    {
        [Test]
        [ExpectedException("System.ArgumentNullException")]
        public void OpenFile_ThrowsException_IfNullArgumentPassed()
        {
            //Arrange
            var writer = new CSVWriter();
            //Act
            writer.OpenFile(null);
            writer.Dispose();
        }

        [Test]
        [TestCase(Description = "Test is used to test if null columns are passed, if the CSVWriter.Write method is changed by removing null check this test will fail")]
        public void Write_DoesnotWriteToFile_WhenColumnsArrayIsNull()
        {
            //Arrange
            var writer = new CSVWriter();
            var dir = Environment.CurrentDirectory + "\\test_data\\newContacts.csv";
            writer.OpenFile(dir);
            //Act
            writer.Write(null);
            writer.Dispose();
            //Assert
            Assert.IsTrue(new FileInfo(dir).Length == 0);
        }

        [Test]
        public void Write_WritesColumnsToFile_WhenColumnsArePassed()
        {
            //Arrange
            var writer = new CSVWriter();
            var dir = Environment.CurrentDirectory + "\\test_data\\newContacts.csv";
            writer.OpenFile(dir);
            string[] columns = { "Mariam Madden", "P.O. Box 954, 1447 Eget Rd.|Yakima|Nova Scotia|8770FU|Iceland", "1 87 146 7952-0549", "nonummy.ac@Namporttitorscelerisque.edu" };
            //Act
            writer.Write(columns);
            writer.Dispose();
            //Assert
            var columnsText = File.ReadAllText(dir);
            Assert.AreEqual(columns, columnsText.Trim().Split('\t'));
        }
    }
}
