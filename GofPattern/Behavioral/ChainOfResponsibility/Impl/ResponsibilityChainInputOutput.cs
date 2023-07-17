using GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility.Impl;

public class ResponsibilityChainInputOutput<TIn, TOut> : AbstractResponsibilityChainInputOutput<
        IResponsibilityChainInputOutput<TIn, TOut>, TIn, TOut>,
    IResponsibilityChainInputOutput<TIn, TOut>
{
    private readonly Predicate<TIn> _predicate;
    private readonly TOut _executeResult;

    public ResponsibilityChainInputOutput(Predicate<TIn> predicate, TOut executeResult)
    {
        _predicate = predicate;
        _executeResult = executeResult;
    }

    protected override bool IsResponsible(TIn input) => _predicate.Invoke(input);

    protected override TOut Process(TIn input) => _executeResult;
}