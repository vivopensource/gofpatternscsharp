namespace GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

public interface ICommand<in TRequest> where TRequest : ICommandRequest
{
    void AddRequest(TRequest commandRequest);

    void Execute();
}