using GofPattern.Structural.ChainOfResponsibility.Exceptions;

namespace GofPattern.Structural.ChainOfResponsibility;

public abstract class Chain<TIn> : NextInChain<IChain<TIn>>, IChain<TIn>
{
    public abstract bool IsResponsible(TIn input);
    protected abstract void ExecuteResponsibility(TIn input);

    public void Execute(TIn input)
    {
        if (IsResponsible(input))
            ExecuteResponsibility(input);
        else
        {
            if (Next is null)
                throw new MissingResponsibilityInChainException();

            Next.Execute(input);
        }
    }
}

public abstract class Chain<TIn, TOut> : NextInChain<IChain<TIn, TOut>>, IChain<TIn, TOut>
{
    public abstract bool IsResponsible(TIn input);
    protected abstract TOut ExecuteResponsibility(TIn input);

    public TOut Execute(TIn input)
    {
        if (IsResponsible(input))
            return ExecuteResponsibility(input);

        if (Next is null)
            throw new MissingResponsibilityInChainException();

        return Next.Execute(input);
    }
}