using Core.Console.Interfaces;
using GofPatterns.Structural.BridgePattern.Implementations;

namespace GofConsoleApp.Examples.Structural.BridgePattern.MultipleImplementations;

// Abstraction in bridge pattern
internal interface IManagement : IBridgeAbstractionsImpl<IProcess, Employee> { }

// Refined abstraction - Event management
internal class EventManagement : BridgeAbstractionsImpl<IProcess, Employee>, IManagement
{
    public EventManagement(string purpose, IConsoleLogger logger)
    {
        logger.Log($"Managing event for: {purpose}.");
    }
}

// Refined abstraction - Travel management
internal class TravelManagement : BridgeAbstractionsImpl<IProcess, Employee>, IManagement
{
    public TravelManagement(string purpose, IConsoleLogger logger)
    {
        logger.Log($"Managing travel for: {purpose}.");
    }
}