namespace GofPatterns.Behavioral.MediatorPattern;

public class Mediator<TColleagueIdentifier, TInput> : IMediator<TColleagueIdentifier, TInput> where TColleagueIdentifier : notnull
{
    private readonly Dictionary<TColleagueIdentifier, IMediatorColleague<TColleagueIdentifier, TInput>> colleagueObjects = new();

    internal void Add(IMediatorColleague<TColleagueIdentifier, TInput> colleague)
    {
        colleagueObjects[colleague.Identifier] = colleague;
    }

    public virtual void Send(TColleagueIdentifier identifier, TInput input)
    {
        var colleague = colleagueObjects[identifier];
        colleague.Process(input);
    }
}