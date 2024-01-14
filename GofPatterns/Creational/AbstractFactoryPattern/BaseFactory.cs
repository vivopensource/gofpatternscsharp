namespace GofPatterns.Creational.AbstractFactoryPattern;

/// <summary>
/// Abstract factory implementation.
/// </summary>
/// <typeparam name="TFactory"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public class BaseFactory<TFactory, TOutput> : IBaseFactory<TFactory, TOutput>
    where TFactory : IFactory<TOutput> where TOutput : IFactoryItem
{
    public TOutput Create(TFactory factory)
    {
        return factory.Create();
    }
}