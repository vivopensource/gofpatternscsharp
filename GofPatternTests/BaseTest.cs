using Core.Console;
using Moq;

namespace GofPatternTests;

internal class BaseTest
{
    protected BaseTest()
    {
        MockLogger = new Mock<ConsoleLogger>();
    }

    protected Mock<ConsoleLogger> MockLogger { get; }
}