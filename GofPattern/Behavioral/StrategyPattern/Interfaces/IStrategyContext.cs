namespace GofPattern.Behavioral.StrategyPattern.Interfaces;

/// <summary>
///     Strategy is a behavioral design pattern that turns a set of behaviors into objects
///     and makes them interchangeable inside original context object.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public interface IStrategyContext<TInput>
{
    IStrategy<TInput>? Strategy { get; }
    void SetStrategy(IStrategy<TInput> strategy);

    void ExecuteStrategy(TInput input);
}

/// <summary>
///     Strategy is a behavioral design pattern that turns a set of behaviors into objects
///     and makes them interchangeable inside original context object.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IStrategyContext<TInput, TOutput>
{
    IStrategy<TInput, TOutput>? Strategy { get; }
    void SetStrategy(IStrategy<TInput, TOutput> strategy);

    TOutput ExecuteStrategy(TInput input);
}