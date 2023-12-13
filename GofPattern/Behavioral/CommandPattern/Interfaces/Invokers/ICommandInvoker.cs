using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofPattern.Behavioral.CommandPattern.Interfaces.Invokers;

/// <summary>
/// Base Command Invoker interface for command pattern.
/// Classes or interfaces inheriting from this interface represent the command invoker.
/// Responsibilities of the command invoker are to hold the commands and execute the commands.
/// The client class creates command invokers to deal with the commands.
/// Invoker can be equated with the context classes.
/// </summary>
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