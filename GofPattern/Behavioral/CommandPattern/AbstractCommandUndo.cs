using GofPattern.Behavioral.CommandPattern.Interfaces;
using GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofPattern.Behavioral.CommandPattern;

public abstract class AbstractCommandUndo<TRequest> : ICommandUndo<TRequest> where TRequest : ICommandRequest
{
    protected TRequest? Request;

    public void AddRequest(TRequest commandRequest)
    {
        Request = commandRequest;
    }

    public abstract void Execute();

    public abstract void UnExecute();
}