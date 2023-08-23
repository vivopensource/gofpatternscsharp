using Moq;
using NUnit.Framework;
using Example = GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Example;

namespace GofPatternTests.Examples.Behavioral;

[TestFixture]
internal class ChainOfResponsibilityExampleTests : BaseTest
{
    [Test]
    public void ChainOfResponsibilityExampleInput_Execute()
    {
        // act
        var actualResult = new Example().Execute(MockLogger.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Exactly(30));
    }

    [Test]
    public void ChainOfResponsibilityExampleInputOutput_Execute()
    {
        // act
        var actualResult =
            new GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.InputOutput.Example()
                .Execute(MockLogger.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Exactly(40));
    }
}