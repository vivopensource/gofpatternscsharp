namespace GofPattern.Behavioral.Strategy.Interfaces;

public interface IStrategy<in TInput>
{
    void Execute(TInput input);
}

public interface IStrategy<in TInput, out TOutput>
{
    TOutput Execute(TInput input);
}