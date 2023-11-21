using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

public interface ICommandUndoInvoker<in TCommand, TCommandRequest> : ICommandInvoker
    where TCommand : ICommand<TCommandRequest>
    where TCommandRequest : ICommandRequest
{
    void AddCommand(TCommand command, bool undoFlag);
}