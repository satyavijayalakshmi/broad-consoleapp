using Com.Br.Sorter;
using Com.Br.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchAppUnitTests.Com.Br.Writer
{
    public class FileWriterTest
    {
        private FileWriter _fileWriter;

        [SetUp]
        public void SetUp()
        {
            _fileWriter = new FileWriter();
        }


        [Test]
        public async Task FileWriter_CreateNewFile()
        {
            string filePath = Path.Combine(Path.GetTempPath(), "test.txt");
            string fileContent = "Test Input";

            await _fileWriter.WriteOutputFile(filePath, fileContent);

            Assert.IsTrue(File.Exists(filePath));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Test]
        public async Task FileWriter_WriteFile()
        {
            string filePath = Path.Combine(Path.GetTempPath(), "test.txt");
            string inputLine1 = "Broadridge";
            string inputLine2 = "Solutions";

            await _fileWriter.WriteOutputFile(filePath, inputLine1);
            await _fileWriter.WriteOutputFile(filePath, inputLine2);

            string actualText = await File.ReadAllTextAsync(filePath);
            string expectedText = inputLine1 + "\r\n" + inputLine2 + "\r\n";
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
