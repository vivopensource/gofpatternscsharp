using Core.Console.Interfaces;
using GofPatterns.Behavioral.CommandPattern;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.OnlineShopComponents;

internal class ProductRequest : ICommandRequest
{
    private readonly IConsoleLogger logger;
    private readonly string name;

    public ProductRequest(IConsoleLogger logger, string name)
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