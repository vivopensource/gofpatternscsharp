﻿using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;

internal class ResponsibilityFoo : AbstractResponsibility
{
    public ResponsibilityFoo(IConsoleLogger logger) : base(logger, "FooCoR") { }

    public override bool IsResponsible(string input)
    {
        return "Foo".Equals(input);
    }
}