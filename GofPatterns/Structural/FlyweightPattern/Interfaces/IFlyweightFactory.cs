namespace GofPatterns.Structural.FlyweightPattern.Interfaces;

public interface IFlyweightFactory<in TType, in TInput>
{
    IFlyweight<TInput> GetObject(TType type);
}