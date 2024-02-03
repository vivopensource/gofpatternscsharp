using Core.Console.Interfaces;
using GofPatterns.Structural.BridgePattern;

namespace GofConsoleApp.Examples.Structural.BridgePattern.Marker;

// Implementor for bridge pattern
internal interface IProcess 
    : IBridgeImplementation // (Marker)
{
    void Process(Employee emp, IConsoleLogger logger);
}

// Concrete implementor - Register
internal class Registration : IProcess
{
    public void Process(Employee emp, IConsoleLogger logger)
    {
        logger.Log($" - Registering employee: {emp.Id} [{emp.FirstName} {emp.LastName}].");
    }
}

// Concrete implementor - Task assignment
internal class TaskAssignment : IProcess
{
    private readonly string name;

    public TaskAssignment(string name)
    {
        this.name = name;
    }

    public void Process(Employee emp, IConsoleLogger logger)
    {
        logger.Log($" - Assigning employee {emp.Id} [{emp.FirstName} {emp.LastName}] with task [{name}].");
    }
}