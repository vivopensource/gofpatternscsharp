using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.StrategyPattern.SenderComponents.Strategies;
using GofPatterns.Behavioral.StrategyPattern;
using GofPatterns.Behavioral.StrategyPattern.Exception;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Behavioral.StrategyPattern;

[TestFixture]
internal class StrategyContextTests
{
    [Test]
    public void ConstructorStrategy_AssignsStrategy()
    {
        // arrange
        var emailStrategy = new EmailStrategy(logger);

        // act
        var actualResult = new StrategyContext<string>(emailStrategy).Strategy;

        // assert
        Assert.That(actualResult, Is.Not.Null);
    }

    [Test]
    public void SetStrategy_AssignsStrategy()
    {
        // arrange
        var emailStrategy = new EmailStrategy(logger);

        // act
        sut.SetStrategy(emailStrategy);

        // assert
        Assert.That(sut.Strategy, Is.Not.Null);
    }

    [Test]
    public void ExecuteStrategy_IfStrategyAssignNotAssigned_ThrowsException()
    {
        // act - assert
        Assert.Throws<MissingStrategyException>(() => sut.ExecuteStrategy(string.Empty));
    }

    [Test]
    public void ExecuteStrategy_RunsUnderlyingStrategy()
    {
        // arrange
        var mockLogger = new Mock<IConsoleLogger>();
        var emailStrategy = new EmailStrategy(mockLogger.Object);
        sut.SetStrategy(emailStrategy);

        // act
        sut.ExecuteStrategy(string.Empty);

        // assert
        mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void ExecuteStrategy_RunsLatestUnderlyingStrategy()
    {
        // arrange
        var mockLoggerEmail = new Mock<IConsoleLogger>();
        var emailStrategy = new EmailStrategy(mockLoggerEmail.Object);
        sut.SetStrategy(emailStrategy);

        var mockLoggerLetter = new Mock<IConsoleLogger>();
        var letterStrategy = new LetterStrategy(mockLoggerLetter.Object);
        sut.SetStrategy(letterStrategy);

        // act
        sut.ExecuteStrategy(string.Empty);

        // assert
        Assert.That(sut.Strategy, Is.TypeOf<LetterStrategy>());
        mockLoggerEmail.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        mockLoggerLetter.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }

    private readonly IStrategyContext<string> sut = new StrategyContext<string>();
    private readonly IConsoleLogger logger = Mock.Of<IConsoleLogger>();
}