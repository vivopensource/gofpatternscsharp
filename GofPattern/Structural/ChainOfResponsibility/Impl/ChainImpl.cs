namespace GofPattern.Structural.ChainOfResponsibility.Impl;

public class ChainImpl<TIn> : Chain<TIn>
{
    private readonly Predicate<TIn> _predicate;
    private readonly Delegate _execute;

    public ChainImpl(Predicate<TIn> predicate, Delegate execute)
    {
        _predicate = predicate;
        _execute = execute;
    }

    public override bool IsResponsible(TIn input) => _predicate.Invoke(input);

    protected override void ExecuteResponsibility(TIn input)
    {
        _execute.DynamicInvoke(input);
    }
}

public class ChainImpl<TIn, TOut> : Chain<TIn, TOut>
{
    private readonly Predicate<TIn> _predicate;
    private readonly TOut _executeResult;

    public ChainImpl(Predicate<TIn> predicate, TOut executeResult)
    {
        _predicate = predicate;
        _executeResult = executeResult;
    }

    public override bool IsResponsible(TIn input) => _predicate.Invoke(input);

    protected override TOut ExecuteResponsibility(TIn input) => _executeResult;
}