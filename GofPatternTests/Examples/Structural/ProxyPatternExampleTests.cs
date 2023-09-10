using GofConsoleApp.Examples.Structural.ProxyPattern;
using GofConsoleApp.Examples.Structural.ProxyPattern.CachedOutput;
using Moq;
using NUnit.Framework;

namespace GofPatternTests.Examples.Structural;

[TestFixture]
internal class ProxyPatternExampleTests : BaseTest
{
    [Test]
    public void ProxyPatternExampleCachedOutput_Execute()
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
        var actualResult = new ProxyPatternExampleCachedOutput().Execute(MockConsoleLogger.Object, MockInputReader.Object);

        // assert
        Assert.That(actualResult, Is.True);
        MockInputReader.Verify(x => x.AcceptInput(), Times.Exactly(expectedCount));
    }
}