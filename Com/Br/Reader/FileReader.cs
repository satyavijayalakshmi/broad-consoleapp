using Com.Br.Counter;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Com.Br.Reader
{
    public class FileReader
    {

        private const int FileBufferReadSize = 8192;

        public static async IAsyncEnumerable<string> ReadInputFile(string inputFilePath)
        {
            StreamReader inputFileStreamReader = null;

            FileStream inputFileStream = null;

            string inputLine;

            try
            {
                Console.WriteLine("Processing input file..." + inputFilePath);

                inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, FileBufferReadSize, useAsync: true);

                inputFileStreamReader = new StreamReader(inputFileStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: FileBufferReadSize);

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