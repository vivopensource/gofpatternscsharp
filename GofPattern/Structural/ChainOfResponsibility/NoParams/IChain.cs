namespace GofPattern.Structural.ChainOfResponsibility.NoParams;

public interface IChain: INextInChain<IChain>
{
    bool IsResponsible();
    void Execute();
}
public interface IChain<TOut>: INextInChain<IChain<TOut>>
{
    bool IsResponsible();
    TOut Execute();
}