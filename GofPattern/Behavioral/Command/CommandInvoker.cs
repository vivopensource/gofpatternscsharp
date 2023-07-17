using GofPattern.Behavioral.Command.Interfaces;

namespace GofPattern.Behavioral.Command;

public class CommandInvoker<TCommand, TCommandRequest> : ICommandInvoker<TCommand, TCommandRequest>
    where TCommand : ICommand<TCommandRequest> where TCommandRequest : ICommandRequest
{
    private IList<TCommand> commands;

    public CommandInvoker() => commands = new List<TCommand>();

    public void AddCommand(TCommand command) => commands.Add(command);

    public void ExecuteCommand()
    {
        if (commands.Count < 1)
            return;

        foreach (var command in commands)
            command.Execute();

        EmptyCommandList();
    }

    private void EmptyCommandList() => commands = new List<TCommand>();
}