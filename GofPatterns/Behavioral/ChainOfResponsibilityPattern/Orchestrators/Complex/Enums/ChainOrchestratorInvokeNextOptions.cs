namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Complex.Enums;

public enum ChainOrchestratorInvokeNextOptions
{
    InvokeNextAlways,
    InvokeNextWhenResponsible,
    InvokeNextWhenNotResponsible,
    InvokeNextNever
}