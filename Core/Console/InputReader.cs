using Core.Console.Interfaces;

namespace Core.Console;

internal class InputReader : IInputReader
{
    private readonly TextReader reader;

    public InputReader(TextReader reader)
    {
        this.reader = reader;
    }

    public string AcceptInput()
    {
        return reader.ReadLine()!;
    }
}