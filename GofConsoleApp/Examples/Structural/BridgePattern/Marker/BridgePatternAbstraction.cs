using Core.Console.Interfaces;
using GofPatterns.Structural.BridgePattern;

namespace GofConsoleApp.Examples.Structural.BridgePattern.Marker;

// Abstraction in bridge pattern
internal interface IManagement
    : IBridgeAbstraction<IProcess> // (Marker)
{
    void Manage(Employee emp);
}

// Refined abstraction - Event management
internal class EventManagement : IManagement
{
    private readonly IConsoleLogger logger;
    private readonly List<IProcess> impls;

    public EventManagement(string purpose, IConsoleLogger logger, params IProcess[] impls)
    {
        this.logger = logger;
        this.impls = new List<IProcess>(impls);

        logger.Log($"Managing event for: {purpose}.");
    }

    public void Manage(Employee emp)
    {
        impls.ForEach(impl => impl.Process(emp, logger));
    }
}

// Refined abstraction - Travel management
internal class TravelManagement : IManagement
{
    private readonly IConsoleLogger logger;
    private readonly List<IProcess> impls;

    public TravelManagement(string purpose, IConsoleLogger logger, params IProcess[] impls)
    {
        this.logger = logger;
        this.impls = new List<IProcess>(impls);

        logger.Log($"Managing travel for: {purpose}.");
    }

    public void Manage(Employee emp)
    {
        impls.ForEach(impl => impl.Process(emp, logger));
    }
}