using Com.Br;
using Com.Br.Counter;
using Com.Br.Reader;
using Com.Br.Sorter;
using Com.Br.Writer;
using FileSearchApp.Com.Br;
using Microsoft.Extensions.DependencyInjection;

namespace FileSearchApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("############################### Input ########################################");
            if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
            {
                HelpText();
                Environment.Exit(0);
            }

            if (args.Length == 1)
            {
                OutFilePathError();
                Environment.Exit(0);
            }

            if (args.Length != 2)
            {
                ArgumentError();
                Environment.Exit(0);
            }

            string inputFilePath = args[0];
            string ouputFilePath = args[1];
            ValidateFilePathAndExtension(inputFilePath, ouputFilePath);

            
            Console.WriteLine("Application is running with the following arguments:");
            Console.WriteLine($"Argument 1: {inputFilePath}");
            Console.WriteLine($"Argument 2: {ouputFilePath}");

            var fileAnalyzerService = serviceProvider.GetService<IFileAnalyzer>();
            fileAnalyzerService?.ProcessFile(inputFilePath, ouputFilePath);


        }

        static void ValidateFilePathAndExtension(string inputFilePath, string ouputFilePath)
        {
            if ((Path.GetExtension(inputFilePath).ToLower() != ".txt") || (Path.GetExtension(ouputFilePath).ToLower() != ".txt"))
            {
                Console.WriteLine("Error: Arg 1 & Arg 2 file path's must have a .txt extension.");
                Environment.Exit(0);
            }

            if (!File.Exists(inputFilePath))
            {
                FilePathError(inputFilePath);
                Environment.Exit(0);
            }           
        }

        static void HelpText()
        {
            Console.WriteLine("Usage: FileSearchApp [arg1] [arg2]");
            Console.WriteLine("[arg1] - Input file path to search the word counts");
            Console.WriteLine("[arg2] - Output file path to publish the results");
            Console.WriteLine();
            Console.WriteLine("You must pass exactly 2 arguments.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --help, -h    Help message");            
            Console.WriteLine("  [arg1]   Provide input file path to search the word count as first argument");
            Console.WriteLine("  [arg21]   Provide output file path as second argument to publish the results");
        }

        static void ArgumentError()
        {
            Console.WriteLine("Error: You must pass exactly 2 arguments.");
            Console.WriteLine("Use --help or -h for usage information.");
        }

        static void FilePathError(string filePath)
        {
            Console.WriteLine($"Error: The file '{filePath}' does not exist.Please provide a valid file path.");            
        }

        static void OutFilePathError()
        {
            Console.WriteLine($"[arg2] is missing - Please provide output file path to publish the results");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFileAnalyzer, FileAnalyzer>();
            services.AddTransient<IWordSorter, WordSorter>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IWordCounter, WordCounter>();
            services.AddTransient<IFileWriter, FileWriter>();
        }
    }
}