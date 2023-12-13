using Core.Console.Interfaces;
using GofPattern.Behavioral.StatePattern;
using GofPattern.Behavioral.StatePattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample;

internal class BulbStateContext : StateContext<BulbStateContext>
{
    public BulbStateContext(IState<BulbStateContext> defaultState, IConsoleLogger logger) : base(defaultState)
    {
        Logger = logger;
    }

    public IConsoleLogger Logger { get; }
}