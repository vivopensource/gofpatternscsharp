namespace GofPatterns.Structural.CompositePattern;

/// <summary>
/// Leaf in composite pattern.
/// </summary>
public interface ILeaf : IComponent {}

/// <summary>
/// Leaf in composite pattern that accepts input.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface ILeaf<in TInput> : IComponent<TInput> {}