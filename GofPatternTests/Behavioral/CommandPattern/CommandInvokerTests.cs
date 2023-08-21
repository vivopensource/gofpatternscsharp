using Core.Console;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandInvoker;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Behavioral.CommandPattern;

[TestFixture]
internal class CommandInvokerTests
{
    [SetUp]
    public void Setup()
    {
        var log = ConsoleExtensions.GetLoggerFactory().CreateLogger<CommandInvokerTests>();
        props.MockLog = new Mock<ConsoleLogger>(log);
        props.Sut = new Restaurant(props.MockLog.Object);
    }

    [Test]
    public void HandleCommands_InvokesAllCommands()
    {
        // arrange
        const int expectedResult = 3;
        var sut = props.Sut;

        // act
        sut.DeliverPizza(3);
        sut.DeliverBurger(5);
        sut.EatBurger(6);
        sut.HandleCommands();

        // assert
        props.MockLog.Verify(m => m.LogInformation(It.IsAny<string>()), Times.Exactly(expectedResult));
    }

    [Test]
    public void HandleCommands_InvokesNothingIfNoCommands()
    {
        // arrange
        const int expectedResult = 0;

        // act
        props.Sut.HandleCommands();

        // assert
        props.MockLog.Verify(m => m.LogInformation(It.IsAny<string>()), Times.Exactly(expectedResult));
    }

    private TestProps props;

    private struct TestProps
    {
        public Restaurant Sut { get; set; }
        public Mock<ConsoleLogger> MockLog { get; set; }
    }
}