namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Enums;

public enum ChainOrchestratorInvokeNextOptions
{
    InvokeNextAlways,
    InvokeNextWhenResponsible,
    InvokeNextWhenNotResponsible,
    InvokeNextNever
}