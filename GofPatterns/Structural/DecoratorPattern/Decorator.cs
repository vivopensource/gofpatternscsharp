namespace GofPatterns.Structural.DecoratorPattern;

public abstract class Decorator<TType> : IDecorator<TType> where TType : IDecorator<TType>
{
    protected readonly TType WrappedComponent;

    protected Decorator(TType wrappedComponent)
    {
        WrappedComponent = wrappedComponent;
    }

    public virtual void Execute()
    {
        WrappedComponent.Execute();
    }
}

public class Decorator<TType, TInput> : IDecorator<TType, TInput> where TType : IDecorator<TType, TInput>
{
    protected readonly TType WrappedComponent;

    protected Decorator(TType wrappedComponent)
    {
        WrappedComponent = wrappedComponent;
    }

    public virtual void Execute(TInput input)
    {
        WrappedComponent.Execute(input);
    }
}