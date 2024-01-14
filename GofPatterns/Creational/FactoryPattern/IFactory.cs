namespace GofPatterns.Creational.FactoryPattern;

/// <summary>
/// Factory interface.
/// Part of factory pattern.
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IFactory<in TInput, out TOutput> where TOutput : IFactoryItem
{
    TOutput Create(TInput input);
}