namespace GofPattern.Behavioral.StatePattern.Interfaces;

/// <summary>
/// Base Context interface for state pattern. 
/// Classes or interfaces inheriting from this interface are associated to a particular state within context.
/// States are created by the client class and passed to the context, which determines the current state of the given context. 
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
public interface IStateContext<TContext> where TContext : IStateContext<TContext>
{
    void SetState(IState<TContext> state);

    void Execute();

    public IState<TContext> State { get; }
}