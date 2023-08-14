namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Enums;

public enum ChainOrchestratorInvokeNextOptions
{
    InvokeNextAlways,
    InvokeNextWhenResponsible,
    InvokeNextWhenNotResponsible,
    InvokeNextNever
}