using Core.Console.Interfaces;
using GofPatterns.Behavioral.MediatorPattern;

namespace GofConsoleApp.Examples.Behavioral.MediatorPattern;

internal class ChatPerson : MediatorColleague<string, string>
{
    private readonly IConsoleLogger logger;

    public ChatPerson(string identifier, Mediator<string, string> mediator, IConsoleLogger logger) :
        base(identifier, mediator)
    {
        this.logger = logger;
    }

    public override void Process(string input) => Listening(input);

    private void Listening(string input) => logger.Log($"Listening '{Identifier}': {input}");
}