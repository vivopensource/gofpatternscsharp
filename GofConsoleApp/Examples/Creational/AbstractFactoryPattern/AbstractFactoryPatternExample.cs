using GofConsoleApp.Examples.Creational.AbstractFactoryPattern.Components;
using GofPatterns.Creational.AbstractFactoryPattern;

namespace GofConsoleApp.Examples.Creational.AbstractFactoryPattern;

internal class AbstractFactoryPatternExample : BaseExample
{
    protected override bool Execute()
    {
        var baseFactory = new BaseFactory<IFactory<ICar>, ICar>();

        ICarFactory hatchbackFactory = new HatchbackFactory();
        ICar hatchbackCar = baseFactory.Create(hatchbackFactory);
        Logger.Log($"Car: {hatchbackCar.Name}, Engine type: {hatchbackCar.EngineType}, Fuel: {hatchbackCar.Fuel}");

        ICarFactory sedanFactory = new SedanFactory();
        ICar sedanCar = baseFactory.Create(sedanFactory);
        Logger.Log($"Car: {sedanCar.Name}, Engine type: {sedanCar.EngineType}, Fuel: {sedanCar.Fuel}");

        return true;
    }
}