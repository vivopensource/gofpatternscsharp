namespace GofPattern.Behavioral.ChainOfResponsibilityPattern.Exceptions;

public sealed class MissingResponsibilityException : Exception
{
    public MissingResponsibilityException() : base("No responsibility found in chain!") { }
}