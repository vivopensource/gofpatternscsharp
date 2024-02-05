using Core.Console.Interfaces;
using GofPatterns.Structural.CompositePattern;

namespace GofConsoleApp.Examples.Structural.CompositePattern;

internal interface IResource : IComponent { }

internal class Employee : ILeaf, IResource
{
    private readonly string name;
    private readonly IConsoleLogger logger;

    public Employee(string name, IConsoleLogger logger)
    {
        this.name = name;
        this.logger = logger;
    }

    public void Process()
    {
        logger.Log($" - Employee working: {name}.");
    }
}

internal class Team : Composite, IResource
{
    private readonly string name;
    private readonly IConsoleLogger logger;

    public Team(string name, IConsoleLogger logger)
    {
        this.name = name;
        this.logger = logger;
    }

    public override void Process()
    {
        logger.Log("----------------------------------------");
        logger.Log($"Team: {name}.");
        base.Process();
    }
}