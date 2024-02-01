namespace GofPatterns.Behavioral.CommandPattern;

public interface ICommandUndo<in TRequest> : ICommand<TRequest> where TRequest : ICommandRequest
{
    void UnExecute();
}