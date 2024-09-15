using Com.Br;

namespace FileSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
            {
                HelpText();
                return;
            }

            if (args.Length != 2)
            {
                ArgumentError();
                return;
            }

            string inputFilePath = args[0];
            string ouputFilePath = args[1];
            ValidateInputFile(inputFilePath);


            //TO-DO: Do I need to check for file extension?

            Console.WriteLine("Application is running with the following arguments:");
            Console.WriteLine($"Argument 1: {inputFilePath}");
            Console.WriteLine($"Argument 2: {ouputFilePath}");

            FileAnalyzer.ProcessFile(inputFilePath, ouputFilePath);


        }

        static void ValidateInputFile(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                FilePathError(inputFilePath);
                return;
            }

            if (Path.GetExtension(inputFilePath).ToLower() != ".txt")
            {
                Console.WriteLine("Error: The input file must have a .txt extension.");
                return;
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
            Console.WriteLine($"Error: The file '{filePath}' does not exist.");
            Console.WriteLine("Please provide a valid file path.");           
        }
    }
}