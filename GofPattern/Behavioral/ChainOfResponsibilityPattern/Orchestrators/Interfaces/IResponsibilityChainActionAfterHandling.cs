namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainActionAfterHandling<TInput>
{
    // ReSharper disable UnusedMemberInSuper.Global

    Action? ActionAfterHandling { get; set; }

    Action<TInput>? ActionInputAfterHandling { get; set; }
}