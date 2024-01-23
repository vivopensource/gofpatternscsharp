namespace GofPatterns.Behavioral.CommandPattern;

/// <summary>
/// Command invoker class for command pattern.
/// It is responsible for holding the commands and executing the commands.
/// It can be directly used as a command invoker class, or inherited by other classes to make them command invoker.
/// </summary>
public class CommandInvoker<TCommand, TCommandRequest> : ICommandInvoker<TCommand, TCommandRequest>
    where TCommand : ICommand<TCommandRequest> where TCommandRequest : ICommandRequest
{
    private IList<TCommand> commands = new List<TCommand>();

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