using GofPattern.Behavioral.Command.Interfaces;

namespace GofPattern.Behavioral.Command;

public abstract class AbstractCommand<TRequest> : ICommand<TRequest> where TRequest : ICommandRequest
{
    protected TRequest? Req;

    public void AddRequest(TRequest commandRequest) => Req = commandRequest;

    public abstract void Execute();
}