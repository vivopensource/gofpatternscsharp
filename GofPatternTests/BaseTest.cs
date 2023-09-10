using Core.Console.Interfaces;
using Moq;
using NUnit.Framework;

namespace GofPatternTests;

internal class BaseTest
{
    protected BaseTest()
    {
        MockConsoleLogger = new Mock<IConsoleLogger>();
        MockInputReader = new Mock<IInputReader>();
    }

    [SetUp]
    public void Setup()
    {
        MockConsoleLogger = new Mock<IConsoleLogger>();
        MockInputReader = new Mock<IInputReader>();
    }

    protected Mock<IConsoleLogger> MockConsoleLogger { get; private set; }

    protected Mock<IInputReader> MockInputReader { get; private set; }
}