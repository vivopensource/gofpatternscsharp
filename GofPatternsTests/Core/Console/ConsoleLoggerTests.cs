using Core.Console;
using Core.Extensions;
using NUnit.Framework;

namespace GofPatternsTests.Core.Console;

[TestFixture]
internal class ConsoleLoggerTests
{
    [Test]
    public void Log_PrintsInfoToConsole()
    {
        // arrange
        using var logFactory = ConsoleExtensions.GetLoggerFactory();
        var logger = new ConsoleLogger(logFactory.CreateLogger(string.Empty));

        // act - assert
        Assert.DoesNotThrow(() => logger.Log("Test", 123));
    }
}