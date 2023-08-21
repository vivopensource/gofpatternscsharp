using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput;
using NUnit.Framework;
using Example = GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Example;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityExampleTests
{

    [Test]
    public void ChainOfResponsibilityExampleInput_Execute()
    {
        // act
        var actualResult = new Example().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void ChainOfResponsibilityExampleInputOutput_Execute()
    {
        // act
        var actualResult = new GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Example().Execute();

        // assert
        Assert.That(actualResult, Is.True);
    }
}