namespace GofPattern.Structural.ChainOfResponsibility.Exceptions;

public class MissingResponsibilityInChainException : Exception
{
    public MissingResponsibilityInChainException() : base("Missing responsibility in chain exception!") {}
}