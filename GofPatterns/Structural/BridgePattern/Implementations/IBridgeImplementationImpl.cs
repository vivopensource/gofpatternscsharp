namespace GofPatterns.Structural.BridgePattern.Implementations;

/// <summary>
/// Bridge implementation interface.
/// </summary>
public interface IBridgeImplementationImpl : IBridgeImplementation
{
    void Execute();
}

/// <summary>
/// Bridge implementation interface with input.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IBridgeImplementationImpl<in TInput> : IBridgeImplementation
{
    void Execute(TInput input);
}