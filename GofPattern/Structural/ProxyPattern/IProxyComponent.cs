namespace GofPattern.Structural.ProxyPattern;

public interface IProxyComponent<in TInput>
{
    void Process(TInput input);
}

public interface IProxyComponent<in TInput, out TOutput>
{
    TOutput Process(TInput input);
}