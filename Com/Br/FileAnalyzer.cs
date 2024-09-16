using Com.Br.Counter;
using Com.Br.Reader;

namespace Com.Br
{
    public class FileAnalyzer
    {
        public static async void ProcessFile(string inputFilePath, string outputFilePath)
        {
            var wordCountResult = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            await foreach (var wordCountLine in FileReader.ReadInputFile(inputFilePath))
            {
                Console.WriteLine("wordCountLine..." + wordCountLine);
                await WordCounter.Counter(wordCountLine);
            }
            Console.WriteLine("wordCountResult..." + wordCountResult.Count);
            if (wordCountResult != null)
            {

                var wordCountSortedResult = WordSorter.Sorter(wordCountResult);

                foreach (var result in wordCountSortedResult)
                {
                    Console.WriteLine($"{result.Key}: {result.Value}");
                }

                Console.WriteLine("Exit by pressing any key...");
                Console.ReadKey();
            }

        }
    }
}