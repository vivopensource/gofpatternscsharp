﻿namespace GofPatterns.Behavioral.StatePattern;

/// <summary>
/// Base State interface for state pattern. 
/// Classes or interfaces inheriting from this interface represent a particular state within context. 
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
public interface IState<in TContext> where TContext : IStateContext<TContext>
{
    void Execute(TContext context);

    string Name { get; }
}

/// <summary>
/// Base State interface for state pattern. 
/// Classes or interfaces inheriting from this interface represent a particular state within context.
/// It returns a value after execution.
/// </summary>
/// <typeparam name="TContext">IStateContext</typeparam>
/// <typeparam name="TOut">Output</typeparam>
public interface IState<in TContext, out TOut> where TContext : IStateContext<TContext, TOut>
{
    TOut Execute(TContext context);

    string Name { get; }
}