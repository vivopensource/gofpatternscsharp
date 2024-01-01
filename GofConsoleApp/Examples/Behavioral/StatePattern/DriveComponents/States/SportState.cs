using static GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents.EnumStatePatternDriveExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents.States;

internal class SportState : DriveState
{
    private const int FuelConsumption = 4;

    public SportState() : base(Sport) { }

    public override string Execute(DriveStateContext context)
    {
        return $"Better pickup, high fuel consumption. {Info(context, FuelConsumption)}";
    }
}