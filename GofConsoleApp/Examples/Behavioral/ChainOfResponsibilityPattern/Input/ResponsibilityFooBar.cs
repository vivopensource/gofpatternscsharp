﻿using Core.Console.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.Input;

internal class ResponsibilityFooBar : AbstractResponsibility
{
    public ResponsibilityFooBar(IConsoleLogger logger) : base(logger, "FooBarCoR") { }

    public override bool IsResponsible(string input)
    {
        return "FooBar".Equals(input);
    }
}