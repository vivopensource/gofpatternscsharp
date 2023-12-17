using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofPatterns.Structural.ProxyPattern;

public class ProxyBoundedInput<TInput> : IProxyBoundedInput<TInput> where TInput : notnull
{
    private readonly IProxyComponent<TInput> component;

    protected ProxyBoundedInput(IProxyComponent<TInput> component, IEnumerable<TInput> boundedInputs)
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

public class ProxyBoundedInput<TInput, TOutput> : IProxyBoundedInput<TInput, TOutput> where TInput : notnull
{
    private readonly IProxyComponent<TInput, TOutput> component;

    protected ProxyBoundedInput(IProxyComponent<TInput, TOutput> component, IEnumerable<TInput> boundedInputs)
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