namespace GofPatterns.Behavioral.CommandPattern;

public abstract class CommandUndo<TRequest> : ICommandUndo<TRequest> where TRequest : ICommandRequest
{
    protected TRequest? Request;

    public void AddRequest(TRequest commandRequest)
    {
        Request = commandRequest;
    }

    public abstract void Execute();

    public abstract void UnExecute();
}