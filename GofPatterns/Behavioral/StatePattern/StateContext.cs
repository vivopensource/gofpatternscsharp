﻿namespace GofPatterns.Behavioral.StatePattern;

/// <summary>
/// Context class for state pattern. 
/// It is responsible for holding the current state, executing the state, and changing the state.
/// It can be directly used as a context class, or inherited by other classes to make them context.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
public class StateContext<TContext> : IStateContext<TContext> where TContext : IStateContext<TContext>
{
    public StateContext(IState<TContext> defaultState)
    {
        State = defaultState;
    }

    public void SetState(IState<TContext> state)
    {
        State = state;
    }

    public virtual void Execute()
    {
        object thisObject = this;
        var context = (TContext) thisObject;
        State.Execute(context);
    }

    public IState<TContext> State { get; private set; }
}

/// <summary>
/// Context class for state pattern. 
/// It is responsible for holding the current state, executing the state, and changing the state.
/// It can be directly used as a context class, or inherited by other classes to make them context.
/// It returns a value after execution.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
/// <typeparam name="TOut">Output</typeparam>
public class StateContext<TContext, TOut> : IStateContext<TContext, TOut> where TContext : IStateContext<TContext, TOut>
{
    public StateContext(IState<TContext, TOut> defaultState)
    {
        State = defaultState;
    }

    public void SetState(IState<TContext, TOut> state)
    {
        State = state;
    }

    public virtual TOut Execute()
    {
        object thisObject = this;
        var context = (TContext) thisObject;
        return State.Execute(context);
    }

    public IState<TContext, TOut> State { get; private set; }
}