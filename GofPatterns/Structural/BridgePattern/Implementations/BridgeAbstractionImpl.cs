namespace GofPatterns.Structural.BridgePattern.Implementations;

/// <summary>
/// Bridge abstraction class with single implementation.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
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

public class BridgeAbstractionImpl<TImplementation, TInput> : IBridgeAbstractionImpl<TImplementation, TInput>
    where TImplementation : IBridgeImplementationImpl<TInput>
{
    public void Add(TImplementation implementation)
    {
        Implementation = implementation;
    }

    public void Execute(TInput input)
    {
        Implementation!.Execute(input);
    }

    public TImplementation? Implementation { get; private set; }
}