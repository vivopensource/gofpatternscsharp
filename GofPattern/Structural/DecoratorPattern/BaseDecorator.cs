namespace GofPattern.Structural.DecoratorPattern;

public abstract class BaseDecorator<TType> : IDecoratorComponent<TType> where TType : IDecoratorComponent<TType>
{
    private readonly TType wrappedComponent;

    protected BaseDecorator(TType wrappedComponent)
    {
        this.wrappedComponent = wrappedComponent;
    }

    public virtual void Execute()
    {
        wrappedComponent.Execute();
    }
}

public class BaseDecorator<TType, TInput> : IDecoratorComponent<TType, TInput> where TType : IDecoratorComponent<TType, TInput>
{
    private readonly TType wrappedComponent;

    protected BaseDecorator(TType wrappedComponent)
    {
        this.wrappedComponent = wrappedComponent;
    }

    public virtual void Execute(TInput input)
    {
        wrappedComponent.Execute(input);
    }
}