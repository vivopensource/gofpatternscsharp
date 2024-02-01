using Core.Console.Interfaces;
using GofPatterns.Behavioral.ObserverPattern;

namespace GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;

internal class PersonAndrewSmith : ISubscriber<string>
{
    private readonly IConsoleLogger logger;

    public PersonAndrewSmith(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Update(string input)
    {
        logger.Log($"Andrew Smith received: {input}");
    }
}