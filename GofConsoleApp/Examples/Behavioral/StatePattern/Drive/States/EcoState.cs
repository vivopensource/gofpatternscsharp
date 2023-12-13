using static GofConsoleApp.Examples.Behavioral.StatePattern.Drive.EnumStatePatternDriveExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.Drive.States;

internal class EcoState : DriveState
{
    private const int FuelConsumption = 3;

    public EcoState() : base(Eco) { }

    public override string Execute(DriveStateContext context)
    {
        return $"Normal pickup, normal fuel consumption. {Info(context, FuelConsumption)}";
    }
}