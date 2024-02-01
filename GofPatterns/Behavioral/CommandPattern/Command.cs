namespace GofPatterns.Behavioral.CommandPattern;

/// <summary>
/// 
/// They can be directly used as a command, or inherited by other classes to make them command
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public abstract class Command<TRequest> : ICommand<TRequest> where TRequest : ICommandRequest
{
    protected TRequest? Request;

    public void AddRequest(TRequest commandRequest)
    {
        Request = commandRequest;
    }

    public abstract void Execute();
}