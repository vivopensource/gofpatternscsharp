namespace GofPatterns.Structural.CompositePattern;

/// <summary>
/// Component in composite pattern.
/// </summary>
public interface IComponent
{
    void Process();
}

/// <summary>
/// Component in composite pattern that accepts input.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IComponent<in TInput>
{
    void Process(TInput input);
}