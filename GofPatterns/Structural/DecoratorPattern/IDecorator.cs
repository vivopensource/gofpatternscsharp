namespace GofPatterns.Structural.DecoratorPattern;

public interface IDecorator<TType> where TType : IDecorator<TType>
{
    void Execute();
}

public interface IDecorator<TType, in TInput> where TType : IDecorator<TType, TInput>
{
    void Execute(TInput input);
}