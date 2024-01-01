using Core.Console.Interfaces;
using GofPatterns.Behavioral.StatePattern;
using GofPatterns.Behavioral.StatePattern.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.BulbComponents;

internal class BulbStateContext : StateContext<BulbStateContext>
{
    public BulbStateContext(IState<BulbStateContext> defaultState, IConsoleLogger logger) : base(defaultState)
    {
        Logger = logger;
    }

    public IConsoleLogger Logger { get; }
}