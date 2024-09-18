using Com.Br.Counter;
using Com.Br.Reader;
using Com.Br.Sorter;
using Com.Br.Writer;
using FileSearchApp.Com.Br;

namespace Com.Br
{
    public class FileAnalyzer : IFileAnalyzer
    {

        private readonly IFileReader _fileReader;

        private readonly IWordCounter _wordCounter;

        private readonly IWordSorter _wordSorter;

        private readonly IFileWriter _fileWriter;

        public FileAnalyzer(IFileReader reader, IWordCounter counter, IWordSorter sorter, IFileWriter writer)
        {
            _fileReader = reader;
            _wordCounter = counter;
            _wordSorter = sorter;
            _fileWriter = writer;
        }

        public async Task ProcessFile(string inputFilePath, string outputFilePath)
        {
            var wordCountResult = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            await foreach (var wordCountLine in _fileReader.ReadInputFile(inputFilePath))
            {
                wordCountResult = await _wordCounter.Counter(wordCountLine);
            }
            
            if (wordCountResult != null)
            {

                var wordCountSortedResult = _wordSorter.Sorter(wordCountResult);
                Console.WriteLine("##############################################################################");
                

                foreach (var result in wordCountSortedResult)
                {
                    await _fileWriter.WriteOutputFile(outputFilePath, $"{result.Key},{result.Value}");
                }                
            }

            Console.WriteLine("############ Results published in " + outputFilePath + " file... #############");

            Environment.Exit(1);

        }
    }
}