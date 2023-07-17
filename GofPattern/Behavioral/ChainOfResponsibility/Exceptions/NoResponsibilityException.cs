namespace GofPattern.Behavioral.ChainOfResponsibility.Exceptions;

public class NoResponsibilityException : Exception
{
    public NoResponsibilityException() : base("No responsibility found in chain exception!") { }
}