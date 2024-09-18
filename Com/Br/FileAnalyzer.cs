using Com.Br.Counter;
using Com.Br.Reader;

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
                Console.WriteLine("############################### Output #######################################");
                foreach (var result in wordCountSortedResult)
                {
                    
                    Console.WriteLine($"{result.Key},{result.Value}");
                   
                }
                Console.WriteLine("##############################################################################");

            }

            Environment.Exit(1);

        }
    }
}