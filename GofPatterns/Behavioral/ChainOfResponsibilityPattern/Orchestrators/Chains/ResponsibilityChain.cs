using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

public class ResponsibilityChain<TInput> : AbstractResponsibilityChain<ResponsibilityChain<TInput>, IResponsibility<TInput>>
{
    internal ResponsibilityChain(IResponsibility<TInput> responsibility) : base(responsibility) { }
}

public class ResponsibilityChain<TInput, TOutput> : AbstractResponsibilityChain<ResponsibilityChain<TInput, TOutput>,
    IResponsibility<TInput, TOutput>>
{
    public ResponsibilityChain(IResponsibility<TInput, TOutput> responsibility) : base(responsibility) { }
}