namespace GofPatterns.Structural.ProxyPattern.Interfaces;

public interface IProxyBoundedInput<TInput> : IProxyComponent<TInput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; }
}

public interface IProxyBoundedInput<TInput, out TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; }
}