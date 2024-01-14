using GofPatterns.Creational.FactoryPattern;

namespace GofConsoleApp.Examples.Creational.FactoryPattern;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

internal class FactoryPatternExample : BaseExample
{
    protected override bool Execute()
    {
        var factory = new CarFactory();

        ICar hatchbackCar = factory.Create(nameof(Hatchback));
        Logger.Log($"Car: {hatchbackCar.Name}, Engine type: {hatchbackCar.EngineType}, Fuel: {hatchbackCar.Fuel}");

        ICar sedanCar = factory.Create(nameof(Sedan));
        Logger.Log($"Car: {sedanCar.Name}, Engine type: {sedanCar.EngineType}, Fuel: {sedanCar.Fuel}");

        return true;
    }
}

internal interface ICar : IFactoryItem
{
    string Name { get; }
    string EngineType { get; }
    string Fuel { get; }
}

internal class Hatchback : ICar
{
    public string Name => nameof(Hatchback);
    public string EngineType => "V6";
    public string Fuel => "Diesel";
}

internal class Sedan : ICar
{
    public string Name => nameof(Sedan);
    public string EngineType => "V8";
    public string Fuel => "Petrol";
}

// Factory
internal class CarFactory : IFactory<string, ICar>
{
    public ICar Create(string input) =>
        input switch
        {
            nameof(Hatchback) => new Hatchback(),
            nameof(Sedan) => new Sedan()
        };
}