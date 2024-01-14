using GofPatterns.Creational.AbstractFactoryPattern;

namespace GofConsoleApp.Examples.Creational.AbstractFactoryPattern.Components;

internal interface ICarFactory : IFactory<ICar> { }

internal class HatchbackFactory : ICarFactory
{
    public ICar Create()
    {
        return new Hatchback();
    }
}

internal class SedanFactory : ICarFactory
{
    public ICar Create() => new Sedan();
}