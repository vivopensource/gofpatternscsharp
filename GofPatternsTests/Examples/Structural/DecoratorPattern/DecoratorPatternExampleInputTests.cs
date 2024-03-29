﻿using GofConsoleApp.Examples.Structural.DecoratorPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural.DecoratorPattern;

[TestFixture]
internal class DecoratorPatternExampleInputTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        const int expectedVerifyCount = 3;

        MockInputReader.Setup(x => x.AcceptInput()).Returns("Test notification");

        var sut = new DecoratorPatternExampleInput();

        // act
        var actualResult = sut.Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedVerifyCount));
    }
}