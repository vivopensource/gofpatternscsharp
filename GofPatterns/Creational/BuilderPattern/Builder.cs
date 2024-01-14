namespace GofPatterns.Creational.BuilderPattern;

public abstract class Builder<TInput> : IBuilder<TInput>
{
    protected Builder() {}

    protected Builder(TInput input)
    {
        Append(input);
    }
    
    public IBuilder<TInput> Append(TInput input)
    {
        Build(input);
        return this;
    }

    public abstract TInput Output();

    protected abstract void Build(TInput input);
}