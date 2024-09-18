using Com.Br.Counter;
using Com.Br.Reader;
using Com.Br.Writer;

namespace Com.Br
{
    public class FileAnalyzer
    {
        public static async Task ProcessFile(string inputFilePath, string outputFilePath)
        {
            var wordCountResult = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            await foreach (var wordCountLine in FileReader.ReadInputFile(inputFilePath))
            {
                wordCountResult = await WordCounter.Counter(wordCountLine);
            }
            
            if (wordCountResult != null)
            {

                var wordCountSortedResult = WordSorter.Sorter(wordCountResult);
                Console.WriteLine("##############################################################################");
                

                foreach (var result in wordCountSortedResult)
                {
                    await FileWriter.WriteOutputFile(outputFilePath, $"{result.Key},{result.Value}");
                }                
            }

            Console.WriteLine("############ Results published in " + outputFilePath + " file... #############");

            Environment.Exit(1);

        }
    }
}