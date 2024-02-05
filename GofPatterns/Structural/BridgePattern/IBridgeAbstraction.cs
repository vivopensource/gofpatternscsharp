namespace GofPatterns.Structural.BridgePattern;

/// <summary>
/// Bridge abstraction interface.
/// It acts as a marker interface.
/// </summary>
/// <typeparam name="TImplementation"></typeparam>
public interface IBridgeAbstraction<TImplementation> where TImplementation : IBridgeImplementation { }