namespace GofPatterns.Behavioral.StrategyPattern;

/// <summary>
/// Strategy interface that defines the contract for the strategy pattern.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IStrategy<in TInput>
{
    void Execute(TInput input);

    string Name { get; }
}

/// <summary>
/// Strategy interface that defines the contract for the strategy pattern.
/// It is used when the strategy pattern is used to return a value.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IStrategy<in TInput, out TOutput>
{
    TOutput Execute(TInput input);

    string Name { get; }
}