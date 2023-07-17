using GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility.Impl;

public class ResponsibilityChainInput<TIn> : AbstractResponsibilityChainInput<IResponsibilityChainInput<TIn>, TIn>,
    IResponsibilityChainInput<TIn>
{
    private readonly Predicate<TIn> _predicate;
    private readonly Delegate _execute;

    public ResponsibilityChainInput(Predicate<TIn> predicate, Delegate execute)
    {
        _predicate = predicate;
        _execute = execute;
    }

    protected override bool IsResponsible(TIn input) => _predicate.Invoke(input);

    protected override void Process(TIn input) => _execute.DynamicInvoke(input);
}