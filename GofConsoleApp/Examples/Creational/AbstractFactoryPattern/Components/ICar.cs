using GofPatterns.Creational.AbstractFactoryPattern;

namespace GofConsoleApp.Examples.Creational.AbstractFactoryPattern.Components;

internal interface ICar : IFactoryItem
{
    public string Name { get; }
    public string EngineType { get; }
    public string Fuel { get; }
}

class Hatchback : ICar
{
    public string Name => nameof(Hatchback);
    public string EngineType => "V6";
    public string Fuel => "Diesel";
}

class Sedan : ICar
{
    public string Name => nameof(Sedan);
    public string EngineType => "V8";
    public string Fuel => "Petrol";
}