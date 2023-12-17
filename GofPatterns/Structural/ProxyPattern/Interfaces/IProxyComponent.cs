namespace GofPatterns.Structural.ProxyPattern.Interfaces;

public interface IProxyComponent<in TInput>
{
    void Process(TInput input);
}

public interface IProxyComponent<in TInput, out TOutput>
{
    TOutput Process(TInput input);
}