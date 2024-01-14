namespace GofPatterns.Creational.BuilderPattern;

public interface IBuilder<TInput>
{
    IBuilder<TInput> Append(TInput input);

    TInput Output();
}