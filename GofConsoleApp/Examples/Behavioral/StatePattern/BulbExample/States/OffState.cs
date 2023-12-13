﻿using GofPattern.Behavioral.StatePattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample.EnumStatePatternBulbExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample.States;

internal class OffState : IState<BulbStateContext>
{
    public void Execute(BulbStateContext context)
    {
        context.Logger.Log($"Bulb is {Name} now.");
    }

    public string Name => Off.ToString();
}