using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;
using static GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums.ChainOrchestratorHandleOptions;

namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public abstract class BaseResponsibilityChainOrchestrator<TResponsibilityChain, TResponsibility> :
    IBaseResponsibilityChainOrchestrator<TResponsibilityChain>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain, TResponsibility>
{
    protected void AssembleChain(TResponsibilityChain responsibilityChain, string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
            responsibilityChain.Name = name;

        if (Chain is null)
            Chain = responsibilityChain;
        else
            Chain.SetNext(responsibilityChain);
    }

    protected bool IsResponsible<TInput>(TResponsibilityChain responsibilityChain, TInput input)
    {
        CurrentChain = responsibilityChain;

        var handleWhenResponsible = HandleWhenResponsible == responsibilityChain.HandleOption;

        var responsibility = (responsibilityChain.Responsibility as IBaseResponsibility<TInput>)!;

        var isResponsible = handleWhenResponsible && responsibility.IsResponsible(input);

        return isResponsible;
    }

    public TResponsibilityChain? Chain { get; private set; }

    public TResponsibilityChain? CurrentChain { get; private set; }
}