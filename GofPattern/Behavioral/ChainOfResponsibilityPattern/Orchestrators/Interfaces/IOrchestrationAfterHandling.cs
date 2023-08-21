namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

public interface IOrchestrationAfterHandling<TInput>
{
    // ReSharper disable UnusedMemberInSuper.Global

    Action? ExecuteAfter { get; set; }

    Action<TInput>? ExecuteAfterWithInput { get; set; }
}