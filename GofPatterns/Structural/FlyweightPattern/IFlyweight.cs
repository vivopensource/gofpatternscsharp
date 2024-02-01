namespace GofPatterns.Structural.FlyweightPattern;

public interface IFlyweight<in TInput>
{
    void Action(TInput input);
}