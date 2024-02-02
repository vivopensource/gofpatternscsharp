namespace GofPatterns.Structural.BridgePattern.Implementations;

public class BridgeAbstractionsImpl<TImplementation> : IBridgeAbstractionsImpl<TImplementation>
    where TImplementation : IBridgeImplementationImpl
{
    private readonly List<TImplementation> impls = new();

    public void Add(TImplementation implementation, params TImplementation[] implementations)
    {
        impls.Add(implementation);
        impls.AddRange(implementations);
    }

    public void Execute()
    {
        impls.ForEach(impl => impl.Execute());
    }

    public int ImplementationCount => impls.Count;
}