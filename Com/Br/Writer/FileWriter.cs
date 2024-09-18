namespace Com.Br.Writer
{
    public class FileWriter : IFileWriter
    {
        static Boolean _isAppend = false;

        public async Task WriteOutputFile(string outputFilePath, string outputText)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath, _isAppend))
            {
                _isAppend = true;
                await writer.WriteLineAsync(outputText);
            }
        }
    }
}