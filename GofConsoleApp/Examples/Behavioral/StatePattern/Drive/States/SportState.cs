using static GofConsoleApp.Examples.Behavioral.StatePattern.Drive.EnumStatePatternDriveExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.Drive.States;

internal class SportState : DriveState
{
    private const int FuelConsumption = 4;

    public SportState() : base(Sport) { }

    public override string Execute(DriveStateContext context)
    {
        return $"Better pickup, high fuel consumption. {Info(context, FuelConsumption)}";
    }
}