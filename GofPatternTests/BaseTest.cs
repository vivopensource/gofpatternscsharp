using Core.Console;
using Core.Console.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternTests;

internal class BaseTest
{
    protected BaseTest()
    {
        MockConsoleLogger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());
        MockInputReader = new Mock<IInputReader>();
        // new ConsoleLogger(Mock.Of<ILogger>())
    }

    [SetUp]
    public void Setup()
    {
        MockConsoleLogger = new Mock<ConsoleLogger>(Mock.Of<ILogger>());
        MockInputReader = new Mock<IInputReader>();
    }

    protected Mock<ConsoleLogger> MockConsoleLogger { get; private set; }

    protected Mock<IInputReader> MockInputReader { get; private set; }
}