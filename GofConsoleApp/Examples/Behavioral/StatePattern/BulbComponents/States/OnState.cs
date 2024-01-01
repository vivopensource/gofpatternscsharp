using GofPatterns.Behavioral.StatePattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents.EnumStatePatternBulbExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents.States;

internal class OnState : IState<BulbStateContext>
{
    public void Execute(BulbStateContext context)
    {
        context.Logger.Log($"Bulb is {Name} now.");
    }

    public string Name => On.ToString();
}