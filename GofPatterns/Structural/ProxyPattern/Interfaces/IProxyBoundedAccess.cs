namespace GofPatterns.Structural.ProxyPattern.Interfaces;

public interface IProxyBoundedAccess<TInput> : IProxyComponent<TInput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; } 
}

public interface IProxyBoundedAccess<TInput, out TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; }
}