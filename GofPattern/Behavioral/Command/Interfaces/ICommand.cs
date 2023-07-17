namespace GofPattern.Behavioral.Command.Interfaces;

public interface ICommand<in TRequest> where TRequest : ICommandRequest
{
    void AddRequest(TRequest commandRequest);
    void Execute();
}

