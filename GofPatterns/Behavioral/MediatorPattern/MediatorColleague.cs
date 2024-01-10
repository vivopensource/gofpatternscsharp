using GofPatterns.Behavioral.MediatorPattern.Interfaces;

namespace GofPatterns.Behavioral.MediatorPattern;

public abstract class MediatorColleague<TColleagueIdentifier, TInput> : IMediatorColleague<TColleagueIdentifier, TInput>
    where TColleagueIdentifier : notnull
{
    private readonly Mediator<TColleagueIdentifier, TInput> mediator;

    protected MediatorColleague(TColleagueIdentifier identifier, Mediator<TColleagueIdentifier, TInput> mediator)
    {
        this.mediator = mediator;
        Identifier = identifier;
        mediator.Add(this);
    }

    public abstract void Process(TInput input);

    public void Send(TColleagueIdentifier identifier, TInput input)
    {
        mediator.Send(identifier, input);
    }

    public TColleagueIdentifier Identifier { get; }
}