namespace GofPatterns.Structural.FlyweightPattern.Interfaces;

public interface IFlyweight<in TInput>
{
    void Action(TInput input);
}