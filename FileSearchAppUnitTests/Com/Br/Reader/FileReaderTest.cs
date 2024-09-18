using Com.Br.Counter;
using Com.Br.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchAppUnitTests.Com.Br.Reader
{
    public class FileReaderTest
    {

        private FileReader _fileReader;

        private const int FileBufferReadSize = 8192;

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
        public async Task FileReader_HandleWindows1252Character()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var inputFile = "word.txt";
            var inputFileContent = "Â¢ Â£ Ã± Â£";

            await using (var fileStream = new FileStream(inputFile, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            using (var writer = new StreamWriter(fileStream, Encoding.GetEncoding(1252)))
            {
                await writer.WriteAsync(inputFileContent);
            }            

            List<string> lines = new List<string>();

            using (var inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, FileBufferReadSize, useAsync: true))
            using (var inputFileStreamReader = new StreamReader(inputFileStream, Encoding.GetEncoding(1252), detectEncodingFromByteOrderMarks: true, bufferSize: FileBufferReadSize))
            {
                string inputLine;

                while ((inputLine = await inputFileStreamReader.ReadLineAsync()) != null)
                {
                    lines.Add(inputLine);
                }
            }

            Assert.AreEqual("Â¢ Â£ Ã± Â£", lines[0]);

            File.Delete(inputFile);
        }

        [Test]
        public async Task FileReader_ShouldHandleEmptyFile()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var filePath = "emptyTextfile.txt";

            await File.WriteAllTextAsync(filePath, string.Empty);

            var lines = new List<string>();

            using (var inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, FileBufferReadSize, useAsync: true))
            using (var inputFileStreamReader = new StreamReader(inputFileStream, Encoding.GetEncoding(1252), detectEncodingFromByteOrderMarks: true, bufferSize: FileBufferReadSize))
            {
                string inputLine;

                while ((inputLine = await inputFileStreamReader.ReadLineAsync()) != null)
                {
                    lines.Add(inputLine);
                }
            }

            Assert.IsEmpty(lines);

            File.Delete(filePath);
        }
    }
}
