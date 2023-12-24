using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Behavioral.ChainOfResponsibilityPattern;

[TestFixture]
internal class CorPatternExampleWithOutputTests : BaseTest
{
    [Test]
    public void ChainOfResponsibilityExampleWithInputOutput_Execute()
    {
        // act
        var actualResult =
            new CorPatternExampleWithOutput().Execute(MockConsoleLogger.Object,
                MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(10));
    }
}