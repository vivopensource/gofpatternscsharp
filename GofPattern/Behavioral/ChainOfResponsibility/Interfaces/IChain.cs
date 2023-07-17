namespace GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

public interface IChain<TNext> where TNext : IChain<TNext>
{
    TNext AddNextInChain(TNext next);
}