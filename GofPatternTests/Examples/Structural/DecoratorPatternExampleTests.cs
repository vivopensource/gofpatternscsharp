using GofConsoleApp.Examples.Structural.DecoratorPattern.NoInput;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class DecoratorPatternExampleTests : BaseTest
{
    [Test]
    public void DecoratorPatternExample_Execute()
    {
        // act
        var actualResult = new Example().Execute(MockLogger.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Exactly(2));
    }

    [Test]
    public void DecoratorPatternExampleInput_Execute()
    {
        // act
        var actualResult =
            new GofConsoleApp.Examples.Structural.DecoratorPattern.Input.Example().Execute(MockLogger.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Exactly(4));
    }
}