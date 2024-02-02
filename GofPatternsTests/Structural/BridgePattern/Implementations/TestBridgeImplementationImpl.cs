using Core.Console;
using GofPatterns.Structural.BridgePattern.Implementations;

namespace GofPatternsTests.Structural.BridgePattern.Implementations;

internal class TestBridgeImplementationImpl : IBridgeImplementationImpl
{
    private readonly ConsoleLogger logger;

    public TestBridgeImplementationImpl(ConsoleLogger logger) => this.logger = logger;

    public void Execute()
    {
        logger.Log($"Executed {nameof(TestBridgeImplementationImpl)}");
    }
}