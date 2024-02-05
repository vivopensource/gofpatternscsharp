using Core.Console.Interfaces;
using GofPatterns.Structural.CompositePattern;

namespace GofConsoleApp.Examples.Structural.CompositePattern;

internal interface IDeliveryItem : IComponent<string> { }

internal class DeliveryProduct : ILeaf<string>, IDeliveryItem
{
    private readonly string name;

    public DeliveryProduct(string name, IConsoleLogger logger)
    {
        this.name = name;
        logger.Log($"Packaging: {name}.");
    }

    public void Process(string city) => Console.WriteLine($"Sending '{name}' to {city}.");
}

internal class DeliveryBox : Composite<string>, IDeliveryItem
{
    private readonly int len;
    private readonly int width;
    private readonly int height;
    private readonly IConsoleLogger logger;

    public DeliveryBox(int len, int width, int height, IConsoleLogger logger)
    {
        this.len = len;
        this.width = width;
        this.height = height;
        this.logger = logger;
        Console.WriteLine($"Packaging Box: {len}x{width}x{height} cms.");
    }

    public override void Process(string city)
    {
        logger.Log("----------------------------------------");
        logger.Log($"Sending box '{len}x{width}x{height} cms' to {city}.");
        base.Process(city);
    }
}