using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;
using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.InputOutput;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityPatternExampleTests : BaseTest
{
    [Test]
    public void ChainOfResponsibilityExampleInput_Execute()
    {
        // act
        var actualResult = new ExampleWithInput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(30));
    }

    [Test]
    public void ChainOfResponsibilityExampleInputOutput_Execute()
    {
        // act
        var actualResult =
            new ExampleWithInputOutput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(40));
    }
}