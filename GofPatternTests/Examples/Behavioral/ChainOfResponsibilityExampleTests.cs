using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Output;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityExampleTests
{

    [Test]
    public void ChainOfResponsibilityExampleInput_Execute()
    {
        // act
        var actualResult = new ChainOfResponsibilityExampleInput().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void ChainOfResponsibilityExampleInputOutput_Execute()
    {
        // act
        var actualResult = new ChainOfResponsibilityExampleInputOutput().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }
}