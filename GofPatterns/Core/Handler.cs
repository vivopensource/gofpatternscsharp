namespace GofPatterns.Core;

internal class Handler<TInput>
{
    private readonly Delegate function;

    public Handler(Delegate function)
    {
        this.function = function;
    }

    public void Handle(TInput input)
    {
        function.DynamicInvoke(input);
    }
}

internal class Handler<TInput, TOutput>
{
    private readonly Func<TInput, TOutput> function;

    public Handler(Func<TInput, TOutput> function)
    {
        this.function = function;
    }

    public TOutput Handle(TInput input)
    {
        return function.Invoke(input);
    }
}