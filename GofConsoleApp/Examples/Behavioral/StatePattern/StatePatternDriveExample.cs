using GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents;
using GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents.States;
using GofPatterns.Behavioral.StatePattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StatePattern.DriveComponents.EnumStatePatternDriveExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern;

internal class StatePatternDriveExample : AbstractExample
{
    private readonly IState<DriveStateContext, string> eco = new EcoState();
    private readonly IState<DriveStateContext, string> sport = new SportState();
    private readonly IState<DriveStateContext, string> sportPlus = new SportPlusState();

    protected override bool Execute()
    {
        IStateContext<DriveStateContext, string> drive = new DriveStateContext(eco, CarAge.Get());

        Logger.Log($"Drive mode is {drive.State.Name}.");

        var driveStatus = drive.Execute();
        Logger.Log(driveStatus);

        do
        {
            var inputOption = AcceptInputEnum(Invalid, "drive-mode", Invalid);

            if (IsInvalidOrQuit(inputOption, Invalid, Stop, out var output))
                return output;

            if (drive.State.Name.Equals(inputOption.ToString()))
            {
                Logger.Log($"Drive mode is already {drive.State.Name}.");
                continue;
            }

            switch (inputOption)
            {
                case Eco:
                    drive.SetState(eco);
                    break;
                case Sport:
                    drive.SetState(sport);
                    break;
                case SportPlus:
                    drive.SetState(sportPlus);
                    break;
            }

            driveStatus = drive.Execute();
            Logger.Log(driveStatus);

        } while (true);
    }
}