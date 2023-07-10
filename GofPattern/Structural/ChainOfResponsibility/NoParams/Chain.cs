using GofPattern.Structural.ChainOfResponsibility.Exceptions;

namespace GofPattern.Structural.ChainOfResponsibility.NoParams;

public abstract class Chain : NextInChain<IChain>, IChain
{
    public abstract bool IsResponsible();
    protected abstract void ExecuteResponsibility();

    public void Execute()
    {
        if (IsResponsible())
            ExecuteResponsibility();
        else
        {
            if (Next is null)
                throw new MissingResponsibilityInChainException();

            Next.Execute();
        }
    }
}

public abstract class Chain<TOut> : NextInChain<IChain<TOut>>, IChain<TOut>
{
    public abstract bool IsResponsible();
    protected abstract TOut ExecuteResponsibility();

    public TOut Execute()
    {
        if (IsResponsible())
            return ExecuteResponsibility();

        if (Next is null)
            throw new MissingResponsibilityInChainException();

        return Next.Execute();
    }
}