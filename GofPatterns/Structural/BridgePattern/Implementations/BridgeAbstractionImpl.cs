namespace GofPatterns.Structural.BridgePattern.Implementations;

public class BridgeAbstractionImpl<TImplementation> : IBridgeAbstractionImpl<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    public void Add(TImplementation implementation)
    {
        Implementation = implementation;
    }

    public void Execute()
    {
        Implementation!.Execute();
    }

    public TImplementation? Implementation { get; private set; }
}