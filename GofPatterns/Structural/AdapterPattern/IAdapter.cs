namespace GofPatterns.Structural.AdapterPattern;

public interface IAdapter<out TOutput>
{
    TOutput Request<TInput>(TInput input);
}

public interface IAdapter<TAdaptee, TTarget> { }