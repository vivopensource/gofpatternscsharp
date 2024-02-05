using GofPatterns.Structural.BridgePattern.Implementations;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Structural.BridgePattern.Implementations;

[TestFixture]
[TestOf(typeof(BridgeAbstractionImpl<>))]
internal class BridgeAbstractionImplTests : BaseTest
{
    private readonly IBridgeAbstractionImpl<IBridgeImplementationImpl> sut =
        new BridgeAbstractionImpl<IBridgeImplementationImpl>();

    [Test]
    public void Add_AssignsImplementation()
    {
        // act
        sut.Add(new TestBridgeImplementationImpl(MockConsoleLogger.Object));

        // assert
        Assert.That(sut.Implementation, Is.Not.Null);
    }

    [Test]
    public void Execute_RunsImplementation()
    {
        // arrange
        sut.Add(new TestBridgeImplementationImpl(MockConsoleLogger.Object));

        // act
        sut.Execute();

        // assert
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }
}