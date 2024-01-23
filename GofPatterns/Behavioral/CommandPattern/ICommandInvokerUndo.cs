namespace GofPatterns.Behavioral.CommandPattern;

public interface ICommandInvokerUndo<in TCommand, TCommandRequest> : ICommandInvoker
    where TCommand : ICommand<TCommandRequest>
    where TCommandRequest : ICommandRequest
{
    void AddCommand(TCommand command, bool undoFlag);
}