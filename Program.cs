using Com.Br;

namespace FileSearchApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
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

            await FileAnalyzer.ProcessFile(inputFilePath, ouputFilePath);


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
            Console.WriteLine("  --help, -h    Show this help message");            
            Console.WriteLine("  [arguments]   Provide input file to search the word count as first argument");
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
    }
}