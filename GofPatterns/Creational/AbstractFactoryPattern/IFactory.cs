namespace GofPatterns.Creational.AbstractFactoryPattern;

/// <summary>
/// Factory interface used by abstract factory.
/// Part of abstract factory pattern.
/// </summary>
/// <typeparam name="TOutput"></typeparam>
public interface IFactory<out TOutput> where TOutput : IFactoryItem
{
    TOutput Create();
}