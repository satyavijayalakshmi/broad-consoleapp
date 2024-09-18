namespace Com.Br.Writer
{
    public class FileWriter
    {
        static Boolean _isAppend = false;

        public static async Task WriteOutputFile(string outputFilePath, string outputText)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath, _isAppend))
            {
                _isAppend = true;
                await writer.WriteLineAsync(outputText);
            }
        }
    }
}