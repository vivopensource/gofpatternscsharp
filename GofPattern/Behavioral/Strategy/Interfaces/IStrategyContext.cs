namespace GofPattern.Behavioral.Strategy.Interfaces;

public interface IStrategyContext<TInput>
{
    void SetStrategy(IStrategy<TInput> strategy);

    void ExecuteStrategy(TInput input);

    IStrategy<TInput>? Strategy { get; }
}

public interface IStrategyContext<TInput, TOutput>
{
    void SetStrategy(IStrategy<TInput, TOutput> strategy);

    TOutput ExecuteStrategy(TInput input);

    IStrategy<TInput, TOutput>? Strategy { get; }
}