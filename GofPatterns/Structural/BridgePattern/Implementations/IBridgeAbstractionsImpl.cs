namespace GofPatterns.Structural.BridgePattern.Implementations;

/// <summary>
/// Bridge abstraction interface with multiple implementations.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
public interface IBridgeAbstractionsImpl<TImplementation> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    void Add(TImplementation implementation, params TImplementation[] implementations);

    void Execute();

    int ImplementationCount { get; }
}

/// <summary>
/// Bridge abstraction interface with multiple implementations and input.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
/// <typeparam name="TInput"></typeparam>
public interface IBridgeAbstractionsImpl<TImplementation, in TInput> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl<TInput>
{
    void Add(TImplementation implementation, params TImplementation[] implementations);

    void Execute(TInput input);

    int ImplementationCount { get; }
}