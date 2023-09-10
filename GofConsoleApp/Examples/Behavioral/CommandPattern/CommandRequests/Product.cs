using Core.Console.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Product : ICommandRequest
{
    private readonly IConsoleLogger logger;
    private readonly string name;

    public Product(IConsoleLogger logger, string name)
    {
        this.logger = logger;
        this.name = name;
    }

    public void Purchase()
    {
        logger.Log($"Purchasing '{name}'.");
    }

    public void Return()
    {
        logger.Log($"Returning '{name}'.");
    }
}