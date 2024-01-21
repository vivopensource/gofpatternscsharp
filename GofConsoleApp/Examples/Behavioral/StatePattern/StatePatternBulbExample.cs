using GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents;
using GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents.States;
using GofPatterns.Behavioral.StatePattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents.EnumStatePatternBulbExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern;

internal class StatePatternBulbExample : BaseExample
{
    private readonly IState<BulbStateContext> on = new OnState();
    private readonly IState<BulbStateContext> off = new OffState();

    protected override bool Execute()
    {
        IStateContext<BulbStateContext> bulb = new BulbStateContext(off, Logger);

        Logger.Log($"Bulb is {bulb.State.Name} now.");

        do
        {
            var state = AcceptInputEnum(Invalid, "state", Invalid);

            if (IsInvalidOrQuit(state, Invalid, Quit, out var output))
                return output;

            if (bulb.State.Name.Equals(state.ToString()))
            {
                Logger.Log($"Bulb already in {bulb.State.Name} state.");
                continue;
            }

            switch (state)
            {
                case On:
                    bulb.SetState(on);
                    break;
                case Off:
                    bulb.SetState(off);
                    break;
            }

            bulb.Execute();

        } while (true);
    }
}