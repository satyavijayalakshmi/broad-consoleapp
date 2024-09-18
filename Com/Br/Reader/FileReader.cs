using Com.Br.Counter;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Com.Br.Reader
{
    public class FileReader : IFileReader
    {

        private const int FileBufferReadSize = 8192;

        public async IAsyncEnumerable<string> ReadInputFile(string inputFilePath)
        {
            StreamReader inputFileStreamReader = null;

            FileStream inputFileStream = null;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string inputLine;

            try
            {
                inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, FileBufferReadSize, useAsync: true);

                inputFileStreamReader = new StreamReader(inputFileStream, Encoding.GetEncoding(1252), detectEncodingFromByteOrderMarks: true, bufferSize: FileBufferReadSize);

                while ((inputLine = await inputFileStreamReader.ReadLineAsync()) != null)
                {
                    yield return inputLine;
                }               
            }
            finally
            {          
                if (inputFileStreamReader != null)
                {
                    inputFileStreamReader.Close();
                }

                if (inputFileStream != null)
                {
                    inputFileStream.Close();
                }
            }

        }
    }
}