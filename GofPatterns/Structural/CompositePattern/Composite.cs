using GofPatterns.Core.Extensions;

namespace GofPatterns.Structural.CompositePattern;

/// <summary>
/// Composite concrete class in composite pattern.
/// </summary>
public class Composite : CommonComposite<IComponent>, IComposite
{
    public Composite() : base(new List<IComponent>()) { }

    public virtual void Process()
    {
        Components.ForEach(c => c.Process());
    }
}

/// <summary>
/// Composite concrete class in composite pattern that accepts input.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public class Composite<TInput> : CommonComposite<IComponent<TInput>>, IComposite<TInput>
{
    public Composite() : base(new List<IComponent<TInput>>()) { }

    public virtual void Process(TInput input)
    {
        Components.ForEach(c => c.Process(input));
    }
}

public abstract class CommonComposite<TComponent>
{
    protected List<TComponent> Components;

    protected CommonComposite(List<TComponent> components)
    {
        Components = components;
    }

    public void Add(TComponent component, params TComponent[] components)
    {
        Components.Build(component, components);
    }

    public void Pop()
    {
        if (Components.Any())
            Components.Remove(Components[Components.Count - 1]);
    }

    public void Remove(TComponent component)
    {
        Components.Remove(component);
    }

    public void RemoveAll()
    {
        Components = new List<TComponent>();
    }
}