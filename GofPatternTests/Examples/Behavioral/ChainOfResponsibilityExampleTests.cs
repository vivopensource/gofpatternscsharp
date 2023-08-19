using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput;
using NUnit.Framework;
using ChainOfResponsibilityExample = GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.ChainOfResponsibilityExample;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityExampleTests
{

    [Test]
    public void ChainOfResponsibilityExampleInput_Execute()
    {
        // act
        var actualResult = new ChainOfResponsibilityExample().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void ChainOfResponsibilityExampleInputOutput_Execute()
    {
        // act
        var actualResult = new GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.ChainOfResponsibilityExample().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }
}