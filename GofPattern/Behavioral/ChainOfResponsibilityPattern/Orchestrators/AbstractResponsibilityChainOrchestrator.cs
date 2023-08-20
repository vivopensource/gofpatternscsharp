using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;

namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;

public class AbstractResponsibilityChainOrchestrator<TResponsibilityChain>
    where TResponsibilityChain : AbstractResponsibilityChain<TResponsibilityChain>
{
    protected void AppendChain(TResponsibilityChain responsibilityChain)
    {
        if (Chain is null)
            Chain = responsibilityChain;
        else
            Chain.SetNext(responsibilityChain);
    }

    public TResponsibilityChain? Chain { get; private set; }
}