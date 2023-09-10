using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

public interface ICommandInvoker
{
    int ExecuteCommands();
}

public interface ICommandInvoker<in TCommand, TCommandRequest> : ICommandInvoker
    where TCommand : ICommand<TCommandRequest>
    where TCommandRequest : ICommandRequest
{
    void AddCommand(TCommand command);
}