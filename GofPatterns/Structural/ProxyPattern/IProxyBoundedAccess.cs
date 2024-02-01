namespace GofPatterns.Structural.ProxyPattern;

public interface IProxyBoundedAccess<TInput> : IProxyComponent<TInput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; } 
}

public interface IProxyBoundedAccess<TInput, out TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    ISet<TInput> BoundedInputs { get; }
}