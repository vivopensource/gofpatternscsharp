using GofPatterns.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofPatterns.Behavioral.CommandPattern.Interfaces.Invokers;

public interface ICommandUndoInvoker<in TCommand, TCommandRequest> : ICommandInvoker
    where TCommand : ICommand<TCommandRequest>
    where TCommandRequest : ICommandRequest
{
    void AddCommand(TCommand command, bool undoFlag);
}