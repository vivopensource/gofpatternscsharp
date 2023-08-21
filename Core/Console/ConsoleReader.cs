using Core.Console.Interfaces;

namespace Core.Console;

internal class ConsoleReader : IConsoleReader
{
    private readonly TextReader reader;

    public ConsoleReader(TextReader reader)
    {
        this.reader = reader;
    }

    public string AcceptInput()
    {
        return reader.ReadLine()!;
    }
}