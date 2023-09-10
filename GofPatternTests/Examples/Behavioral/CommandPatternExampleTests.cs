using GofConsoleApp.Examples.Behavioral.CommandPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class CommandPatternExampleTests : BaseTest
{
    [Test]
    public void CommandPatternExample_Execute()
    {
        // act
        var actualResult = new CommandPatternExample().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(5));
    }
}