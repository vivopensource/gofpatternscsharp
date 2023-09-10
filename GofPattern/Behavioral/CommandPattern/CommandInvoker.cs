using GofPattern.Behavioral.CommandPattern.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;
using GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

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

    public int ExecuteCommands()
    {
        var count = commands.Count;
        if (count < 1)
            return 0;

        foreach (var command in commands)
            command.Execute();

        EmptyCommandList();
        return count;
    }

    private void EmptyCommandList()
    {
        commands = new List<TCommand>();
    }
}