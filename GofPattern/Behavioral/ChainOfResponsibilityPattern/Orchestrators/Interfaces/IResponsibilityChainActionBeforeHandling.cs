namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IResponsibilityChainActionBeforeHandling<TInput>
{
    // ReSharper disable UnusedMemberInSuper.Global

    Action? ActionBeforeHandling { get; set; }

    Action<TInput>? ActionInputBeforeHandling { get; set; }
    
}