using Core.Logging;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Chains;
using GofPattern.Behavioral.ChainOfResponsibilityPattern.Responsibilities.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibility.Input.Orchestrators;

internal class ResponsibilityChainOrchestratorInput : ResponsibilityChainOrchestrator<IResponsibility<string>, string>
{
    private readonly ICustomLogger log;

    internal ResponsibilityChainOrchestratorInput(ICustomLogger log)
    {
        this.log = log;
    }

    public override void ExecuteAfterHandling(string input,
        ResponsibilityChain<IResponsibility<string>, string> responsibilityChain)
    {
        log.LogInformation(
            $"HandleOption: {responsibilityChain.HandleOption}, InvokeNextHandlerOption: {responsibilityChain.InvokeNextHandlerOption}");
    }
}