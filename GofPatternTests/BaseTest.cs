using Core.Console;
using Core.Console.Interfaces;
using Moq;

namespace GofPatternTests;

internal class BaseTest
{
    protected BaseTest()
    {
        MockConsoleLogger = new Mock<IConsoleLogger>();
        MockInputReader = new Mock<IInputReader>();
    }

    protected Mock<IConsoleLogger> MockConsoleLogger { get; }
    protected Mock<IInputReader> MockInputReader { get; }
}