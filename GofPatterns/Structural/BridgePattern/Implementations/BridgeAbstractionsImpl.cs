using GofPatterns.Core.Extensions;

namespace GofPatterns.Structural.BridgePattern.Implementations;

/// <summary>
/// Bridge abstraction interface with multiple implementations.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
public class BridgeAbstractionsImpl<TImplementation> : IBridgeAbstractionsImpl<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    private readonly List<TImplementation> impls = new();

    public void Add(TImplementation implementation, params TImplementation[] implementations)
    {
        impls.Build(implementation, implementations);
    }

    public void Execute()
    {
        impls.ForEach(impl => impl.Execute());
    }

    public int ImplementationCount => impls.Count;
}

/// <summary>
/// Bridge abstraction interface with multiple implementations and input.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
/// <typeparam name="TInput"></typeparam>
public class BridgeAbstractionsImpl<TImplementation, TInput> : IBridgeAbstractionsImpl<TImplementation, TInput>
    where TImplementation : IBridgeImplementationImpl<TInput>
{
    private readonly List<TImplementation> impls = new();

    public void Add(TImplementation implementation, params TImplementation[] implementations)
    {
        impls.Build(implementation, implementations);
    }

    public void Execute(TInput input)
    {
        impls.ForEach(impl => impl.Execute(input));
    }

    public int ImplementationCount => impls.Count;
}