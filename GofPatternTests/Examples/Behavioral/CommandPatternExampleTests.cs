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
        var actualResult = new Example().Execute(MockLogger.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Exactly(5));
    }
}