namespace GofPatterns.Creational.AbstractFactoryPattern;

/// <summary>
/// Abstract factory interface.
/// Part of abstract factory pattern.
/// </summary>
/// <typeparam name="TFactory"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IBaseFactory<in TFactory, out TOutput>
    where TFactory : IFactory<TOutput> where TOutput : IFactoryItem
{
    TOutput Create(TFactory factory);
}