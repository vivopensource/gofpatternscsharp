namespace GofPattern.Structural.ProxyPattern;

public class ProxyBoundedInput<TInput> : IProxyComponent<TInput> where TInput : notnull
{
    private readonly IProxyComponent<TInput> component;
    private readonly IEnumerable<TInput> boundedInputs;

    protected ProxyBoundedInput(IProxyComponent<TInput> component, IEnumerable<TInput> boundedInputs)
    {
        this.component = component;
        this.boundedInputs = boundedInputs;
    }

    public void Process(TInput input)
    {
        if (!boundedInputs.Contains(input))
            throw new ArgumentException($"Given input '{input}' is not bounded.");

        component.Process(input);
    }
}

public class ProxyBoundedInput<TInput, TOutput> : IProxyComponent<TInput, TOutput> where TInput : notnull
{
    private readonly IProxyComponent<TInput, TOutput> component;
    private readonly IEnumerable<TInput> boundedInputs;

    protected ProxyBoundedInput(IProxyComponent<TInput, TOutput> component, IEnumerable<TInput> boundedInputs)
    {
        this.component = component;
        this.boundedInputs = boundedInputs;
    }

    public TOutput Process(TInput input)
    {
        if (!boundedInputs.Contains(input))
            throw new ArgumentException($"Given input '{input}' is not bounded.");

        return component.Process(input);
    }
}