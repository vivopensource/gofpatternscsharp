namespace GofPattern.Behavioral.CommandPattern.Interfaces.Commands;

public interface ICommandUndo<in TRequest> : ICommand<TRequest> where TRequest : ICommandRequest
{
    void UnExecute();
}