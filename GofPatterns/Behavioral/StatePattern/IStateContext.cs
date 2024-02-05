namespace GofPatterns.Behavioral.StatePattern;

/// <summary>
/// Base Context interface for state pattern. 
/// Classes or interfaces inheriting from this interface are associated to a particular state within context.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
public interface IStateContext<TContext> where TContext : IStateContext<TContext>
{
    void SetState(IState<TContext> state);

    void Execute();

    public IState<TContext> State { get; }
}

/// <summary>
/// Base Context interface for state pattern. 
/// Classes or interfaces inheriting from this interface are associated to a particular state within context.
/// It returns a value after execution.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
/// <typeparam name="TOut">Output</typeparam>
public interface IStateContext<TContext, TOut> where TContext : IStateContext<TContext, TOut>
{
    void SetState(IState<TContext, TOut> state);

    TOut Execute();

    public IState<TContext, TOut> State { get; }
}