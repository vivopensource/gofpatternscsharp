using Core.Console.Interfaces;
using GofPatterns.Structural.BridgePattern;

namespace GofConsoleApp.Examples.Structural.BridgePattern;

// Abstraction in bridge pattern
internal interface IManagement : IBridgeAbstraction<IProcessEmployee>
{
    void Manage(Employee emp);
}

// Refined abstraction - Event management
internal class EventManagement : IManagement
{
    private readonly IProcessEmployee impl;
    private readonly IConsoleLogger logger;

    public EventManagement(string name, IProcessEmployee impl, IConsoleLogger logger)
    {
        this.impl = impl;
        this.logger = logger;

        logger.Log($"Managing event for: {name}.");
    }

    public void Manage(Employee emp)
    {
        impl.Process(emp, logger);
    }
}

// Refined abstraction - Travel management
internal class TravelManagement : IManagement
{
    private readonly IProcessEmployee impl;
    private readonly IConsoleLogger logger;

    public TravelManagement(string name, IProcessEmployee impl, IConsoleLogger logger)
    {
        this.impl = impl;
        this.logger = logger;

        logger.Log($"Managing travel for: {name}.");
    }

    public void Manage(Employee emp)
    {
        impl.Process(emp, logger);
    }
}