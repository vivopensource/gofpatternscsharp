using Core.Console.Interfaces;
using GofPatterns.Behavioral.ObserverPattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ObserverPattern.Components;

internal class PersonJohnDoe : ISubscriber<string>
{
    private readonly IConsoleLogger logger;

    public PersonJohnDoe(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public void Update(string input)
    {
        logger.Log($"John Doe received: {input}");
    }
}