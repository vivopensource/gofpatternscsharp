using Core.Console;
using Core.Console.Interfaces;
using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal abstract class AbstractFoodCommandRequest : IFoodCommandRequest
{
    private readonly IConsoleLogger log;
    private readonly string name;
    private readonly int count;

    private protected AbstractFoodCommandRequest(IConsoleLogger log, string name, int count)
    {
        this.log = log;
        this.name = name;
        this.count = count;
    }

    public void Serve()
    {
        log.LogInformation($"Serving {count} {name}.");
    }

    public void Pack()
    {
        log.LogInformation($"Packing {count} {name}.");
    }
}