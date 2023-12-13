using static GofConsoleApp.Examples.Behavioral.StatePattern.Drive.EnumStatePatternDriveExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.Drive.States;

internal class SportPlusState : DriveState
{
    private const int FuelConsumption = 5;

    public SportPlusState() : base(SportPlus) { }

    public override string Execute(DriveStateContext context)
    {
        return $"Best pickup, highest fuel consumption. {Info(context, FuelConsumption)}";
    }
}