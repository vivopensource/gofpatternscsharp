using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Behavioral.ChainOfResponsibilityPattern;

[TestFixture]
internal class ChainOfResponsibilityPatternExampleInputWithOutputTests : BaseTest
{
    [Test]
    public void ChainOfResponsibilityExampleWithInputOutput_Execute()
    {
        // act
        var actualResult =
            new ChainOfResponsibilityPatternExampleInputWithOutput().Execute(MockConsoleLogger.Object,
                MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(10));
    }
}