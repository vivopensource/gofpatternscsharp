using GofPatterns.Structural.BridgePattern.Implementations;
using Moq;
using NUnit.Framework;

namespace GofPatternsTests.Structural.BridgePattern.Implementations;

[TestFixture]
[TestOf(typeof(BridgeAbstractionsImpl<>))]
internal class BridgeAbstractionsImplTests : BaseTest
{
    private readonly IBridgeAbstractionsImpl<IBridgeImplementationImpl> sut =
        new BridgeAbstractionsImpl<IBridgeImplementationImpl>();

    [Test]
    public void Add_AssignsImplementation()
    {
        // arrange
        const int expectedCount = 2;

        var impl1 = new TestBridgeImplementationImpl(MockConsoleLogger.Object);
        var impl2 = new TestBridgeImplementationImpl(MockConsoleLogger.Object);

        // act
        sut.Add(impl1, impl2);

        // assert
        Assert.That(sut.ImplementationCount, Is.EqualTo(expectedCount));
    }

    [Test]
    public void Execute_RunsImplementation()
    {
        // arrange
        const int expectedCount = 3;

        var impl1 = new TestBridgeImplementationImpl(MockConsoleLogger.Object);
        var impl2 = new TestBridgeImplementationImpl(MockConsoleLogger.Object);
        sut.Add(impl1, impl2);

        var impl3 = new TestBridgeImplementationImpl(MockConsoleLogger.Object);
        sut.Add(impl3);

        // act
        sut.Execute();

        // assert
        MockConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(expectedCount));
    }
}