namespace GofPattern.Behavioral.Command.Interfaces;

public interface ICommandInvoker<in TCommand, TCommandRequest> where TCommand : ICommand<TCommandRequest>
    where TCommandRequest : ICommandRequest
{
    void AddCommand(TCommand command);
    void ExecuteCommand();
}