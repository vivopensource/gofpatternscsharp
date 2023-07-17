using GofPattern.Behavioral.ChainOfResponsibility.Interfaces;

namespace GofPattern.Behavioral.ChainOfResponsibility;

internal class ChainLink<TNext> where TNext : IChain<TNext>
{
    internal TNext? Next { private set; get; }

    internal void AddNext(TNext next)
    {
        if (Next is null)
            Next = next;
        else
            Next.AddNextInChain(next);
    }
}