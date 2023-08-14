using GofConsoleApp.Examples.Behavioral.CommandPattern;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class CommandPatternExampleTests
{
    [Test]
    public void CommandPatternExample_Execute()
    {
        // act
        var actualResult = new CommandPatternExample().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }
}