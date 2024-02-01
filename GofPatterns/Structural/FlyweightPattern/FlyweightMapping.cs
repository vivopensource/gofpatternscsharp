namespace GofPatterns.Structural.FlyweightPattern;

public class FlyweightMapping<TType, TInput>
{
    public FlyweightMapping(TType flyweightType, IFlyweight<TInput> flyweightObject)
    {
        FlyweightType = flyweightType;
        FlyweightObject = flyweightObject;
    }

    public TType FlyweightType { get; }
    public IFlyweight<TInput> FlyweightObject { get; }
}