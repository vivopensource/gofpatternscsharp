namespace GofPattern.Structural.ChainOfResponsibility;


public interface IChain<TIn>: INextInChain<IChain<TIn>>
{
    bool IsResponsible(TIn input);
    void Execute(TIn input);
}

public interface IChain<TIn, TOut>: INextInChain<IChain<TIn, TOut>>
{
    bool IsResponsible(TIn input);
    TOut Execute(TIn input);
}