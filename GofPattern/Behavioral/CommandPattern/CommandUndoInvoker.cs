using GofPattern.Behavioral.CommandPattern.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;
using GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

namespace GofPattern.Behavioral.CommandPattern;

// ReSharper disable once MemberCanBeProtected.Global

public class CommandUndoInvoker<TCommandUndo, TCommandRequest> : ICommandUndoInvoker<TCommandUndo, TCommandRequest>
    where TCommandUndo : ICommandUndo<TCommandRequest> where TCommandRequest : ICommandRequest
{
    private IList<CommandWrapper> commandWrappers;

    public CommandUndoInvoker()
    {
        commandWrappers = new List<CommandWrapper>();
    }

    public void AddCommand(TCommandUndo command, bool undoFlag)
    {
        commandWrappers.Add(new CommandWrapper(command, undoFlag));
    }

    public int ExecuteCommands()
    {
        var count = commandWrappers.Count;
        if (count < 1)
            return count;

        foreach (var commandWrapper in commandWrappers)
        {
            var undoFlag = commandWrapper.UndoFlag;
            var command = commandWrapper.Command;

            if (undoFlag)
                command.UnExecute();
            else
                command.Execute();
        }

        EmptyCommandList();
        return count;
    }

    private void EmptyCommandList()
    {
        commandWrappers = new List<CommandWrapper>();
    }

    private sealed class CommandWrapper
    {
        public CommandWrapper(TCommandUndo command, bool undoFlag)
        {
            Command = command;
            UndoFlag = undoFlag;
        }

        public TCommandUndo Command { get; }

        public bool UndoFlag { get; }
    }
}