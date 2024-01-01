using GofPatterns.Structural.DecoratorPattern;

namespace GofConsoleApp.Examples.Structural.DecoratorPattern.InputExampleComponents;

internal interface INotifier : IDecoratorComponent<INotifier, string> { }