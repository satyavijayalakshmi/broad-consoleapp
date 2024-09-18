using Com.Br.Counter;
using Com.Br.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchAppUnitTests.Com.Br.Reader
{
    public class FileReaderTest
    {

        private FileReader _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new FileReader();
        }


        [Test]
        public async Task FileReader_ShouldReturnLinesFromFile()
        {
            var inputFile = "word.txt";
            var inputFileContent = "broadridge solutions unitedkingdom";
            await File.WriteAllTextAsync(inputFile, inputFileContent);

            List<string> lines = new List<string>();
            await foreach (var line in _fileReader.ReadInputFile(inputFile))
            {
                lines.Add(line);
            }

            Assert.AreEqual("broadridge solutions unitedkingdom", lines[0]);

            File.Delete(inputFile);
        }

        [Test]
        public void FileReader_HandleFileNotFound()
        {
            var filePath = "nofileexists.txt";

            Assert.ThrowsAsync<FileNotFoundException>(async () =>
            {
                await foreach (var line in _fileReader.ReadInputFile(filePath))
                {
                    
                }
            });
        }

        [Test]
        public async Task FileReader_ShouldHandleEmptyFile()
        {
            var filePath = "emptyfile.txt";
            await File.WriteAllTextAsync(filePath, string.Empty);

            var lines = new List<string>();
            await foreach (var line in _fileReader.ReadInputFile(filePath))
            {
                lines.Add(line);
            }

            Assert.IsEmpty(lines);

            File.Delete(filePath);
        }
    }
}
