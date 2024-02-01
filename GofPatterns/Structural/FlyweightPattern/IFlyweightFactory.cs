namespace GofPatterns.Structural.FlyweightPattern;

public interface IFlyweightFactory<in TType, in TInput>
{
    IFlyweight<TInput> GetObject(TType type);
}