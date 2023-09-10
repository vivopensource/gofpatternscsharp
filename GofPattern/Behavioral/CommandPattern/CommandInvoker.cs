using GofPattern.Behavioral.CommandPattern.Interfaces;

namespace GofPattern.Behavioral.CommandPattern;

// ReSharper disable once MemberCanBeProtected.Global

public class CommandInvoker<TCommand, TCommandRequest> : ICommandInvoker<TCommand, TCommandRequest>
    where TCommand : ICommand<TCommandRequest> where TCommandRequest : ICommandRequest
{
    private IList<TCommand> commands;

    public CommandInvoker()
    {
        commands = new List<TCommand>();
    }

    public void AddCommand(TCommand command)
    {
        commands.Add(command);
    }

    public void HandleCommands()
    {
        if (commands.Count < 1)
            return;

        foreach (var command in commands)
            command.Execute();

        EmptyCommandList();
    }

    private void EmptyCommandList()
    {
        commands = new List<TCommand>();
    }
}