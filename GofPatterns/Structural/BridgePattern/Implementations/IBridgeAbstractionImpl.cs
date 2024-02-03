namespace GofPatterns.Structural.BridgePattern.Implementations;

/// <summary>
/// Bridge abstraction interface with single implementation.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
public interface IBridgeAbstractionImpl<TImplementation> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    void Add(TImplementation implementation);

    void Execute();

    TImplementation? Implementation { get; }
}

/// <summary>
/// Bridge abstraction interface with single implementation and input.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
/// <typeparam name="TInput"></typeparam>
public interface IBridgeAbstractionImpl<TImplementation, in TInput> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl<TInput>
{
    void Add(TImplementation implementation);

    void Execute(TInput input);

    TImplementation? Implementation { get; }
}