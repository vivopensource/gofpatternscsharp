namespace GofPatterns.Behavioral.StatePattern.Interfaces;

/// <summary>
/// Base State interface for state pattern. 
/// Classes or interfaces inheriting from this interface represent a particular state within context. 
/// Most of the time, the client class creates states and  passes them to the context.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
public interface IState<in TContext> where TContext : IStateContext<TContext>
{
    void Execute(TContext context);

    string Name { get; }
}

/// <summary>
/// <inheritdoc cref="IState{TContext}" />
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
/// <typeparam name="TOut">Output</typeparam>
public interface IState<in TContext, out TOut> where TContext : IStateContext<TContext, TOut>
{
    TOut Execute(TContext context);

    string Name { get; }
}