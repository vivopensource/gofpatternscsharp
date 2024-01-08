namespace GofPatterns.Structural.DecoratorPattern;

public abstract class Decorator<TType> : IDecorator<TType> where TType : IDecorator<TType>
{
    private readonly TType wrappedComponent;

    protected Decorator(TType wrappedComponent)
    {
        this.wrappedComponent = wrappedComponent;
    }

    public virtual void Execute()
    {
        wrappedComponent.Execute();
    }
}

public class Decorator<TType, TInput> : IDecorator<TType, TInput> where TType : IDecorator<TType, TInput>
{
    private readonly TType wrappedComponent;

    protected Decorator(TType wrappedComponent)
    {
        this.wrappedComponent = wrappedComponent;
    }

    public virtual void Execute(TInput input)
    {
        wrappedComponent.Execute(input);
    }
}