using GofPatterns.Behavioral.StrategyPattern.Exception;

namespace GofPatterns.Behavioral.StrategyPattern;

/// <summary>
/// Context class that defines the contract for the strategy pattern.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public class StrategyContext<TInput> : IStrategyContext<TInput>
{
    public StrategyContext() { }

    public StrategyContext(IStrategy<TInput> strategy)
    {
        SetStrategy(strategy);
    }

    public void SetStrategy(IStrategy<TInput> strategy)
    {
        Strategy = strategy;
    }

    public void ExecuteStrategy(TInput input)
    {
        if (Strategy is null)
            throw new MissingStrategyException();

        Strategy.Execute(input);
    }

    public IStrategy<TInput>? Strategy { private set; get; }
}

/// <summary>
/// Context class that defines the contract for the strategy pattern.
/// It is used when the strategy pattern is used to return a value.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public class StrategyContext<TInput, TOutput> : IStrategyContext<TInput, TOutput>
{
    public StrategyContext() { }

    public StrategyContext(IStrategy<TInput, TOutput> strategy)
    {
        SetStrategy(strategy);
    }

    public void SetStrategy(IStrategy<TInput, TOutput> strategy)
    {
        Strategy = strategy;
    }

    public TOutput ExecuteStrategy(TInput input)
    {
        if (Strategy is null)
            throw new MissingStrategyException();

        return Strategy.Execute(input);
    }

    public IStrategy<TInput, TOutput>? Strategy { private set; get; }
}