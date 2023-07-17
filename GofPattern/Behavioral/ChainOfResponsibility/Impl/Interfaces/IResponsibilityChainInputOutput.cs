using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility.Impl.Interfaces;

public interface
    IResponsibilityChainInputOutput<TIn, TOut> : IResponsibilityChainInputOutput<
        IResponsibilityChainInputOutput<TIn, TOut>, TIn, TOut> { }