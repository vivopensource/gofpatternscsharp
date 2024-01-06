using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofPatterns.Structural.ProxyPattern;

/// <summary>
/// Proxy Pattern implementation with bounded access.
/// The proxy component will only process the input if it is bounded.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public class ProxyBoundedAccess<TInput> : IProxyBoundedAccess<TInput> where TInput : notnull
{
    private readonly IProxyComponent<TInput> component;

    public ProxyBoundedAccess(IProxyComponent<TInput> component, IEnumerable<TInput> boundedInputs)
    {
        this.component = component;
        BoundedInputs = new HashSet<TInput>(boundedInputs);
    }

    public void Process(TInput input)
    {
        if (!BoundedInputs.Contains(input))
            throw new ArgumentException($"'{input}' is out of bounds");

        component.Process(input);
    }

    public ISet<TInput> BoundedInputs { get; }
}

/// <summary>
/// Proxy Pattern implementation with bounded access.
/// The proxy component will only process the input if it is bounded, and it will return an output.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public class ProxyBoundedAccess<TInput, TOutput> : IProxyBoundedAccess<TInput, TOutput> where TInput : notnull
{
    private readonly IProxyComponent<TInput, TOutput> component;

    public ProxyBoundedAccess(IProxyComponent<TInput, TOutput> component, IEnumerable<TInput> boundedInputs)
    {
        this.component = component;
        BoundedInputs = new HashSet<TInput>(boundedInputs);
    }

    public TOutput Process(TInput input)
    {
        if (!BoundedInputs.Contains(input))
            throw new ArgumentException($"'{input}' is out of bounds");

        return component.Process(input);
    }

    public ISet<TInput> BoundedInputs { get; }
}