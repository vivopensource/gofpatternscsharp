using GofPatterns.Structural.FlyweightPattern.Interfaces;

namespace GofPatterns.Structural.FlyweightPattern;

public class FlyweightFactory<TType, TInput> : IFlyweightFactory<TType, TInput> where TType : notnull
{
    private readonly IDictionary<TType, IFlyweight<TInput>> flyweights;

    public FlyweightFactory(params FlyweightMapping<TType, TInput>[] mappings)
    {
        flyweights = mappings.ToDictionary(mapping => mapping.FlyweightType, mapping => mapping.FlyweightObject);
    }

    public IFlyweight<TInput> GetObject(TType type)
    {
        return flyweights[type];
    }
}