namespace GofPatterns.Structural.BridgePattern.Implementations;

public interface IBridgeAbstractionImpl<TImplementation> : IBridgeAbstraction<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    void Add(TImplementation implementation);

    void Execute();

    TImplementation? Implementation { get; }
}