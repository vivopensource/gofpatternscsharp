using Core.Logging;
using GofPattern.Behavioral.Command.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.Command;

internal interface IFoodCommandRequest : ICommandRequest
{
    void Serve();
    void Pack();
}

internal abstract class AbstractFoodCommandRequest : IFoodCommandRequest
{
    private readonly ICustomLogger log;
    private readonly string name;
    private readonly int count;

    internal AbstractFoodCommandRequest(ICustomLogger log, string name, int count)
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

internal class Pizza : AbstractFoodCommandRequest
{
    internal Pizza(ICustomLogger log, int count = 1) : base(log, nameof(Pizza), count) { }
}

internal class Burger : AbstractFoodCommandRequest
{
    internal Burger(ICustomLogger log, int count = 1) : base(log, nameof(Burger), count) { }
}