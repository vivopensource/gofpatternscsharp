using Core.Console.Interfaces;
using GofPatterns.Structural.BridgePattern.Implementations;

namespace GofConsoleApp.Examples.Structural.BridgePattern.MultipleImplementations;

// Implementor for bridge pattern
internal interface IProcess : IBridgeImplementationImpl<Employee> { }

// Concrete implementor - Register
internal class Registration : IProcess
{
    private readonly IConsoleLogger logger;

    public Registration(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Execute(Employee emp)
    {
        logger.Log($" - Registering employee: {emp.Id} [{emp.FirstName} {emp.LastName}].");
    }
}

// Concrete implementor - Task assignment
internal class TaskAssignment : IProcess
{
    private readonly string name;
    private readonly IConsoleLogger logger;

    public TaskAssignment(string name, IConsoleLogger logger)
    {
        this.logger = logger;
        this.name = name;
    }

    public void Execute(Employee emp)
    {
        logger.Log($" - Assigning employee {emp.Id} [{emp.FirstName} {emp.LastName}] with task [{name}].");
    }
}