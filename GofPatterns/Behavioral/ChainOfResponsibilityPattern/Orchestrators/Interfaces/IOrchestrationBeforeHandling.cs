namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IOrchestrationBeforeHandling<TInput>
{
    // ReSharper disable UnusedMemberInSuper.Global

    Action? ExecuteBefore { get; set; }

    Action<TInput>? ExecuteBeforeWithInput { get; set; }
}