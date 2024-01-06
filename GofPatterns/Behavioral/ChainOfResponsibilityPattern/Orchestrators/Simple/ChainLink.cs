namespace GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Simple;

/// <summary>
/// Chain link part of orchestrator.
/// Contains the responsibility and the next chain.
/// </summary>
/// <typeparam name="TResponsibility"></typeparam>
public class ChainLink<TResponsibility>
{
    internal ChainLink(TResponsibility responsibility)
    {
        Name = GetType().Name;
        Responsibility = responsibility;
    }

    internal void SetNext(ChainLink<TResponsibility> chainLink)
    {
        if (Next is null)
            Next = chainLink;
        else
            Next.SetNext(chainLink);
    }

    public string Name { get; internal set; }

    public TResponsibility Responsibility { get; }

    public ChainLink<TResponsibility>? Next { get; private set; }
}