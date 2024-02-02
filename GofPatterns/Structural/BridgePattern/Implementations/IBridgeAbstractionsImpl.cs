namespace GofPatterns.Structural.BridgePattern.Implementations;

public interface IBridgeAbstractionsImpl<TImplementation> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    void Add(TImplementation implementation, params TImplementation[] implementations);

    void Execute();

    int ImplementationCount { get; }
}