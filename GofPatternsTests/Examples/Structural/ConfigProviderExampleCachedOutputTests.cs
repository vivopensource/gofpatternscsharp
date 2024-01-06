using GofConsoleApp.Examples.Structural.ProxyPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderComponents;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Examples.Structural;

[TestFixture]
internal class ConfigProviderExampleCachedOutputTests : BaseTest
{
    [Test]
    public void Execute_PerformsSuccessfulExampleRun_ReturnsTrue()
    {
        // arrange
        var readerValues = new Queue<string>(new[]
        {
            EnumConfigEnv.Dev.ToString(),
            EnumConfigEnv.Prod.ToString(),
            EnumConfigEnv.Prod.ToString(),
            EnumConfigEnv.Dev.ToString(),
            EnumConfigEnv.Test.ToString(),
            "Quit program"
        });

        var expectedCount = readerValues.Count;

        MockInputReader.Setup(x => x.AcceptInput()).Returns(readerValues.Dequeue);

        // act
        var actualResult = new ConfigProviderExampleCachedOutput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);

        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedCount));
    }
}