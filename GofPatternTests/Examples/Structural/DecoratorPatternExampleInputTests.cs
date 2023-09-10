﻿using GofConsoleApp.Examples.Structural.DecoratorPattern;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class DecoratorPatternExampleInputTests : BaseTest
{
    [Test]
    public void DecoratorPatternExampleWithInput_Execute()
    {
        // arrange
        const int expectedVerifyCount = 3;

        MockInputReader.Setup(x => x.AcceptInput()).Returns("Test notification");

        // act
        var actualResult =
            new DecoratorPatternExampleInput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        // assert - verify
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedVerifyCount));
    }
}