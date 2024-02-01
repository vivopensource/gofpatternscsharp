namespace GofPatterns.Behavioral.MediatorPattern;

public interface IMediatorColleague<TColleagueIdentifier, in TInput> : IMediator<TColleagueIdentifier, TInput>
{
    void Process(TInput input);

    TColleagueIdentifier Identifier { get; }
}