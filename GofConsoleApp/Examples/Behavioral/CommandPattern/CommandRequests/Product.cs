using Core.Console.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests;

internal class Product : ICommandRequest
{
    private readonly IConsoleLogger logger;
    private readonly string name;
    private readonly int count;

    public Product(IConsoleLogger logger, string name, int count)
    {
        this.logger = logger;
        this.name = name;
        this.count = count;
    }

    public void Purchase()
    {
        logger.Log($"Ordering {count} '{name}'.");
    }

    public void Return()
    {
        logger.Log($"Returning {count} '{name}'.");
    }
}