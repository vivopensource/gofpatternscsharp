using Core.Console;
using Core.Extensions;
using GofConsoleApp.Examples;
using Moq;

namespace GofConsoleApp;

internal static class Program
{
    public static void Main(string[] args)
    {
        ExecuteExample(BuildReaderFromArgument(args, Console.In));
    }

    private static void ExecuteExample(TextReader reader)
    {
        const string loggerName = "Program";
        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = logFactory.CreateLogger(loggerName);
        ExampleExecutor.Run(new ConsoleLogger(logger), new InputReader(reader));
    }

    public static TextReader BuildReaderFromArgument(IReadOnlyCollection<string> args, TextReader defaultReader)
    {
        // No arguments provided, use default reader
        if (args.Count < 1)
            return defaultReader;

        // Arguments provided, build reader from arguments
        var readerValues = new Queue<string>(args);
        var mockReader = new Mock<TextReader>();
        mockReader.Setup(m => m.ReadLine()).Returns(readerValues.Dequeue);
        return mockReader.Object;
    }
}