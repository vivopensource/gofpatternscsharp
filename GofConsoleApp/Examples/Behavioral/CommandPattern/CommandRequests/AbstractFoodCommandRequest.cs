using Core.Console;
using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal abstract class AbstractFoodCommandRequest : IFoodCommandRequest
{
    private readonly IConsoleLogger logger;
    private readonly string name;
    private readonly int count;

    private protected AbstractFoodCommandRequest(IConsoleLogger logger, string name, int count)
    {
        this.logger = logger;
        this.name = name;
        this.count = count;
    }

    public void Serve()
    {
        logger.Log($"Serving {count} {name}.");
    }

    public void Pack()
    {
        logger.Log($"Packing {count} {name}.");
    }
}