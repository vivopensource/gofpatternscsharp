namespace GofPattern.Structural.DecoratorPattern;

public interface IDecoratorComponent<TType> where TType : IDecoratorComponent<TType>
{
    void Execute();
}

public interface IDecoratorComponent<TType, in TInput> where TType : IDecoratorComponent<TType, TInput>
{
    void Execute(TInput input);
}