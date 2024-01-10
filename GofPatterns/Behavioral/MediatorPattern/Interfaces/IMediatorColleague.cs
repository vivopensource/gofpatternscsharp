namespace GofPatterns.Behavioral.MediatorPattern.Interfaces;

public interface IMediatorColleague<TColleagueIdentifier, in TInput> : ICommunicator<TColleagueIdentifier, TInput>
{
    void Process(TInput input);

    TColleagueIdentifier Identifier { get; }
}