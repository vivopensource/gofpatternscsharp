namespace GofPattern.Behavioral.CommandPattern.Interfaces;

public interface ICommand<in TRequest> where TRequest : ICommandRequest
{
    void AddRequest(TRequest commandRequest);

    void Execute();
}