using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.RestaurantComponents.Requests;

internal abstract class AbstractFoodRequest : IFoodRequest
{
    private readonly IConsoleLogger logger;
    private readonly string name;
    private readonly int count;

    private protected AbstractFoodRequest(IConsoleLogger logger, string name, int count)
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