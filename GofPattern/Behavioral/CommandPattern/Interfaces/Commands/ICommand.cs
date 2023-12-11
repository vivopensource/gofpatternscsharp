namespace GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

/// <summary>
/// Base Command interface for command pattern.
/// Classes or interfaces inheriting from this interface represent the command.
/// Responsibilities of the command are to hold the request and execute the request.
/// The client class creates commands and passes them to the invoker.
/// Invoker are responsible for executing the command.
/// </summary>
/// <typeparam name="TRequest">ICommandRequest</typeparam>
public interface ICommand<in TRequest> where TRequest : ICommandRequest
{
    void AddRequest(TRequest commandRequest);

    void Execute();
}