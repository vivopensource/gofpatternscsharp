namespace GofPattern.Structural.ChainOfResponsibility;

public interface INextInChain<T>
{
    T AddNextInChain(T next);
}

public abstract class NextInChain<T> : INextInChain<T> where T : INextInChain<T>
{
    protected T? Next;

    public T AddNextInChain(T next)
    {
        if (Next is null)
            Next = next;
        else
            Next.AddNextInChain(next);

        return ReturnThis(this);
    }

    private static T ReturnThis(INextInChain<T> t)
    {
        return (T)t;
    }
}