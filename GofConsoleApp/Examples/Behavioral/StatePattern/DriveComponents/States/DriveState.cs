using GofPatterns.Behavioral.StatePattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents.States;

internal abstract class DriveState : IState<DriveStateContext, string>
{
    protected DriveState(EnumStatePatternDriveExample name)
    {
        Name = name.ToString();
    }

    protected string Info(DriveStateContext context, int fuelConsumption)
    {
        return $"Car Age: {context.CarAge.Age}. Estimated millage: {context.GetDistance(fuelConsumption)}";
    }

    public abstract string Execute(DriveStateContext context);

    public string Name { get; }
}