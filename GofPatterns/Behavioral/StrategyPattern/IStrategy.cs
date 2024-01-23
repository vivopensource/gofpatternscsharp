namespace GofPatterns.Behavioral.StrategyPattern;

public interface IStrategy<in TInput>
{
    void Execute(TInput input);
    string Name { get; }
}

public interface IStrategy<in TInput, out TOutput>
{
    TOutput Execute(TInput input);
    string Name { get; }
}