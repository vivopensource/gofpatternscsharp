using GofPattern.Behavioral.Strategy.Exception;
using GofPattern.Behavioral.Strategy.Interfaces;

namespace GofPattern.Behavioral.Strategy;

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