using GofConsoleApp.Examples.Structural.DecoratorPattern.Input;
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
        var actualResult = new ExampleNoInput().Execute(MockConsoleLogger.Object,
            MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
    }

    [Test]
    public void DecoratorPatternExampleInput_Execute()
    {
        // act
        var actualResult = new ExampleWithInput().Execute(MockConsoleLogger.Object,
            MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(4));
    }
}