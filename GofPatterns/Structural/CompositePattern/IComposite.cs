namespace GofPatterns.Structural.CompositePattern;

/// <summary>
/// Composite in composite pattern.
/// </summary>
public interface IComposite : IComponent
{
    void Add(IComponent component, params IComponent[] components);
    void Pop();
    void Remove(IComponent component);
    void RemoveAll();
}

/// <summary>
/// Composite in composite pattern that accepts input.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IComposite<TInput> : IComponent<TInput>
{
    void Add(IComponent<TInput> component, params IComponent<TInput>[] components);
    void Pop();
    void Remove(IComponent<TInput> component);
    void RemoveAll();
}