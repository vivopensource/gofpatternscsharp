namespace GofPatterns.Behavioral.StrategyPattern;

/// <summary>
/// Context interface that defines the contract for the strategy pattern.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IStrategyContext<TInput>
{
    void SetStrategy(IStrategy<TInput> strategy);

    void ExecuteStrategy(TInput input);

    IStrategy<TInput>? Strategy { get; }
}

/// <summary>
/// Context interface that defines the contract for the strategy pattern.
/// It is used when the strategy pattern is used to return a value.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IStrategyContext<TInput, TOutput>
{
    void SetStrategy(IStrategy<TInput, TOutput> strategy);

    TOutput ExecuteStrategy(TInput input);

    IStrategy<TInput, TOutput>? Strategy { get; }
}